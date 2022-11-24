using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UseKeyAtGate : MonoBehaviour
{

    public KeyBehaviour key;

    public GameObject helpTextObj;
    public TextMeshProUGUI helpText;

    public Image circle;
    public float timer = 5f;

    private bool inTrigger;
    private bool keyPress;
    public bool gateIsopem;

    // Start is called before the first frame update
    void Start()
    {
        circle.enabled = false;
        gateIsopem = false;
    }

    private void Update()
    {
        print("timer= " + timer + " circleEnabled= "  +  circle.enabled + " circleFillAmount= " + circle.fillAmount + " gateIsOpen= " + gateIsopem);
        if (Input.GetKey(KeyCode.E) && inTrigger && key.hasKey)
        {
            keyPress = true;
        } else keyPress = false;

        if (keyPress)
        {
            timer -= Time.deltaTime;
            circle.enabled = true;
            circle.fillAmount = timer / 5f;
        }

        if (timer <= 0)
        {
            timer = 0f;
            circle.fillAmount = 0f;
            circle.enabled = false;
            gateIsopem = true;
        }

        if (timer >= 5f)
        {
            timer = 5f;
            circle.fillAmount = 100f;
            circle.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        if (key.hasKey)
        {
            helpText.text = "Press E to open te gate!";
            helpTextObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        helpText.text = "";
        helpTextObj.SetActive(false);
    }
}
