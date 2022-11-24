using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public bool hasKey;
    public GameObject helpTextObj;
    public GameObject keyObject;
    public GameObject keyUI;
    private bool inTrigger;
    [SerializeField] public TextMeshProUGUI helpText;

    private void Start()
    {
        helpTextObj.SetActive(false);
        keyObject.SetActive(true);
        keyUI.SetActive(false);
        inTrigger = false;
    }

    private void Update()
    {
        //Checks for the Key E and if inTrigger is enabled.
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            print("e key was pressed");
            keyObject.SetActive(false);
            keyUI.SetActive(true);
            helpTextObj.SetActive(false);
            helpText.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        //Checks if the player already has the key
        if (!hasKey)
        {
            //Player does not have the key so show the text to pick it up
            helpText.text = "Press E to pickup the key.";
            helpTextObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        
        //Checks wether the player does NOT have the key so it disables the helpText for picking it up!
        if (!hasKey)
        {
            helpTextObj.SetActive(false);
            helpText.text = "";
        }
    }
}
