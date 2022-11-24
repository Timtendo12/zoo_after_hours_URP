using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finishObjective : MonoBehaviour
{
    public string objectiveFinish;
    
    public AudioSource objectiveStartSound;
    public AudioSource demonLionRoar;
    public AudioSource tickingSFX;
    public AudioSource bgMusicDay;
    public AudioSource bgMusicNight;

    public GameObject closedGate;
    
    [SerializeField] public TextMeshProUGUI objectiveText;
    [SerializeField] public TextMeshProUGUI objectiveTextStatic;
    public enemyTriggerRandomizer enemyTriggerRandomizer;
    public fadeToBlack fader;
    public Material nightSkybox;

    public StartObjective startObjective;
    
    public bool missionFinished;
    public bool isFinish;
    // Start is called before the first frame update

    private void Start()
    {
        bgMusicDay.loop = true;
        bgMusicDay.Play();
        closedGate.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(missionFinished + " " + startObjective.missionStarted);
        if (missionFinished == false && startObjective.missionStarted)
        {
            StartCoroutine(FinishObjective());
        }
    }


    IEnumerator FinishObjective()
    {
        /*
         * TODO:
         * - stop bg_music_day ->
         * - Set UI text -> done
         * - Fade to black -> done
         * - Change Skybox to night -> done
         * - play roar -> done
         * - play background_night_music ->
         * - 
         */
        //fade screen to black
        fader.fade = true;
        bgMusicDay.Stop();
        //play ticking SFX
        tickingSFX.Play();
        yield return new WaitForSeconds(2);
        
        //wait til its dark and play roar
        demonLionRoar.Play();
        yield return new WaitForSeconds(4);
        
        //UI text
        objectiveText.text = objectiveFinish;
        objectiveTextStatic.gameObject.SetActive(true);
        objectiveText.gameObject.SetActive(true);
        //changing to nightmode
        RenderSettings.skybox = nightSkybox;
        closedGate.SetActive(true);
        
        
        //generating js points
        enemyTriggerRandomizer.generateTriggers();

        //playing night music
        bgMusicNight.loop = true;
        bgMusicNight.Play();
        
        objectiveStartSound.Play();
        fader.fade = false;
        yield return new WaitForSeconds(5);
        //turning off screen on text;
        objectiveText.text = "";
        objectiveTextStatic.gameObject.SetActive(false);
        objectiveText.gameObject.SetActive(false);

        //fade back to screen
        fader.fade = false;
        yield return null;
    }
}
