using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{   
    [SerializeField] GameObject FLashlight;
    private bool FLashlightOn = false;

    // Start is called before the first frame update
    void Start()
    {
        FLashlight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (FLashlightOn == false)
            {
                FLashlight.gameObject.SetActive(true);
                FLashlightOn = true;
            }
            else
            {
                FLashlight.gameObject.SetActive(false);
                FLashlightOn = false;
            }
        }
    }
}
