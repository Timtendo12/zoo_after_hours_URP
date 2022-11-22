using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashLight : MonoBehaviour
{
    
    public FlashlightToggle FLscript;
    public GameObject pickUpText;
    public GameObject flashlightObject;
    public GameObject flashlightUI;

    private void Start()
    {
        pickUpText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!FLscript.hasFlashlight) pickUpText.SetActive(true);
        if (Input.GetKeyDown("F"))
    }

    private void OnTriggerExit(Collider other)
    {
        if (pickUpText.activeInHierarchy) pickUpText.SetActive(true);
    }
}
