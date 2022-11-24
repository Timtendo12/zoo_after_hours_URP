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
    public AudioSource demonLionRoar;
    public AudioSource tickingSFX;
    public AudioSource bgMusicDay;
    public AudioSource bgMusicNight;
    
    
    [SerializeField] public TextMeshProUGUI objectiveText;
    [SerializeField] public TextMeshProUGUI objectiveTextStatic;
    public enemyTriggerRandomizer enemyTriggerRandomizer;
    public fadeToBlack fader;
    public Material nightSkybox;

    public finishObjective FinishObjective;
    
    public bool missionStarted;
    public bool isStart;
    public bool isFinish;

    private void Start()
    {
        FinishObjective.missionFinished = false;
        missionStarted = false;
        objectiveStartSound.playOnAwake = false;
        objectiveText.gameObject.SetActive(false);
        objectiveText.text = "";
        objectiveTextStatic.gameObject.SetActive(false);
    }

    private void Update()
    {
        print("CHECK2 >  missionStarted:" + missionStarted + " missionFinished: " + FinishObjective.missionFinished);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!missionStarted && !FinishObjective.missionFinished)
        {
            StartCoroutine(startObjective());
            missionStarted = true;
        }
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
}
