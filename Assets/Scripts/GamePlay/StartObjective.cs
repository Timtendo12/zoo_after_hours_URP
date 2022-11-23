using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartObjective : MonoBehaviour
{
    public string objective;
    public string objectiveFinish;
    public AudioSource objectiveStartSound;
    [SerializeField] public TextMeshProUGUI objectiveText;
    [SerializeField] public TextMeshProUGUI objectiveTextStatic;
    public enemyTriggerRandomizer enemyTriggerRandomizer;
    public GameObject humans;
    public Animator fader;
    public Material nightSkybox;
    public bool missionStarted;
    public bool missionFinished;
    public bool isStart;
    public bool isFinish;

    private void Start()
    {
        missionFinished = false;
        missionStarted = false;
        objectiveStartSound.playOnAwake = false;
        objectiveText.gameObject.SetActive(false);
        objectiveText.text = "";
        objectiveTextStatic.gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        print("[TRIGGER OBJECTIVE START -> ENTER]");
        if (isStart && missionStarted == false && missionFinished == false)
        {
            print("CHECK1 > " + isStart + "" + missionStarted + "" + missionFinished);
            StartCoroutine(startObjective());   
        } else if (isFinish && missionStarted && missionFinished == false)
        {
            print("CHECK2 > " + isStart + "" + missionStarted + "" + missionFinished);
            StartCoroutine(finishObjective());
        } else print("CHECK3 > " + isStart + "" + missionStarted + "" + missionFinished);
    }
    
    IEnumerator startObjective()
    {
        //setting up UI
        objectiveText.text = objective;
        
        //playing sound
        objectiveStartSound.Play();
        
        //showing UI
        objectiveTextStatic.gameObject.SetActive(true);
        objectiveText.gameObject.SetActive(true);
        
        //setting bool to true
        missionStarted = true;
        yield return new WaitForSeconds(5);
        objectiveText.gameObject.SetActive(false);
        objectiveTextStatic.gameObject.SetActive(false);
        objectiveText.text = "";
        yield return null;
    }
    
    IEnumerator finishObjective()
    {
        /*
         * TODO:
         * - Set UI text -> Done
         * - Fade to black -> done
         * - Change Skybox to night -> done
         * - remove NPC's from scene
         */
        //fade screen to black
        fader.SetTrigger("FadeToBlack");
        //UI text
        objectiveText.text = objectiveFinish;
        objectiveText.gameObject.SetActive(true);
        //changing to nightmode
        RenderSettings.skybox = nightSkybox;
        //disabling humans
        humans.SetActive(false);
        enemyTriggerRandomizer.generateTriggers();
        yield return null;
    }
}
