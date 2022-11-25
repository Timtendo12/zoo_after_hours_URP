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

    public GameObject flUI;
    public FlashlightToggle flashlight;

    public GameObject closedGate;

    public TextMeshProUGUI helpText;
    public GameObject helpTextObj;

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
        flUI.SetActive(false);
        flashlight.hasFlashlight = false;
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

        missionFinished = true;
        
        
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
        RenderSettings.fog = true;
        RenderSettings.ambientIntensity = 0f;
        RenderSettings.fogColor = Color.gray;
        RenderSettings.fogDensity = 0.09f;
        closedGate.SetActive(true);
        flUI.SetActive(true);
        flashlight.hasFlashlight = true;
        
        
        //generating js points
        enemyTriggerRandomizer.generateTriggers();

        //playing night music
        bgMusicNight.loop = true;
        bgMusicNight.Play();
        
        objectiveStartSound.Play();
        fader.fade = false;
        yield return new WaitForSeconds(5);
        //turning off screen on text;
        helpText.text = "Press F to turn on the flashlight";
        helpTextObj.SetActive(true);
        yield return new WaitForSeconds(5);
        helpTextObj.SetActive(false);
        helpText.text = "";
        objectiveTextStatic.gameObject.SetActive(false);
        objectiveText.gameObject.SetActive(false);

        //fade back to screen
        fader.fade = false;
        yield return null;
    }
}
