using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{   
    [SerializeField] GameObject FLashlight;
    public bool flashlightOn = false;
    public bool hasFlashlight = false;

    // Start is called before the first frame update
    void Start()
    {
        FLashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasFlashlight)
        {
            if (flashlightOn == false)
            {
                FLashlight.gameObject.SetActive(true);
                flashlightOn = true;
            }
            else
            {
                FLashlight.gameObject.SetActive(false);
                flashlightOn = false;
            }
        }
    }
}
