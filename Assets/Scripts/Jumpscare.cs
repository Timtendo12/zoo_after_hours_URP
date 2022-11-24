using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumpscare : MonoBehaviour
{

    public JSVariable JsVariable;

    //The real fucker right here oy!
    public GameObject player;
    
    //Camera inside JSBox
    public GameObject jsCamera;
    
    //Flashlight model infront of PSX Quad
    public GameObject flUI;


    public fadeToBlack fader;
    public GameObject deathScreen;
    public GameObject postProcessingJs;
    public AudioSource DS_SFX;
    
    //Flashlight gameobject (App animates itself on activation :D)
    public GameObject fl;

    //Scary sound
    public AudioSource jumpscareSound;

    private void Start()
    {
        //making sure it will never loop!
        jumpscareSound.loop = false;
        DS_SFX.loop = false;
        deathScreen.SetActive(false);
    }

    public void jumpscare()
    {
        StartCoroutine(jumpscary());
    }

    IEnumerator jumpscary()
    {
        flUI.SetActive(false);
        jsCamera.SetActive(true);
        player.SetActive(false);
        fl.SetActive(true);
        jumpscareSound.Play();
        
        //TODO: -> Change seconds to a bit more specific be4 production.
        yield return new WaitForSeconds(2);
        fader.fade = true;
        yield return new WaitForSeconds(1);
        postProcessingJs.SetActive(false);
        deathScreen.SetActive(true);
        JsVariable.hasBeenJumpScared = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}
