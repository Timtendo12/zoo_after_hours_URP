using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpFlashLight : MonoBehaviour
{
    
    public FlashlightToggle FLscript;
    public GameObject helpTextObj;
    public GameObject flashlightObject;
    public GameObject flashlightUI;
    private bool inTrigger;
    [SerializeField] public TextMeshProUGUI helpText;

    private void Start()
    {
        helpTextObj.SetActive(false);
        flashlightObject.SetActive(true);
        flashlightUI.SetActive(false);
        inTrigger = false;
    }

    private void Update()
    {
        //Checks for the Key if inTrigger is enabled.
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            print("e key was pressed");
            FLscript.hasFlashlight = true;
            flashlightObject.SetActive(false);
            flashlightUI.SetActive(true);
            StartCoroutine(showFLHelpText());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        //Checks if the player already has the flashlight
        if (!FLscript.hasFlashlight)
        {
            //Player does not have the FL so show the text to pick it up
            helpText.text = "Press E to pickup the flashlight!";
            helpTextObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        
        //Checks wether the player does NOT have the flashlight so it disables the helpText for picking it up!
        if (!FLscript.hasFlashlight)
        {
            helpTextObj.SetActive(false);
            helpText.text = "";
        }
    }
    
    
    //Shows the Help text for using the flashlight for 5 seconds
    IEnumerator showFLHelpText()
    {
        helpText.text = "Press F to turn on the flashlight";
        yield return new WaitForSeconds(5);
        helpTextObj.SetActive(false);
        helpText.text = "";
    }
}
