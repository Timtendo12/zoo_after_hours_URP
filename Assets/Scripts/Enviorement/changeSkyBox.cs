using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSkyBox : MonoBehaviour
{
    public Material daySkyBox;
    public Material nightSkyBox;

    public bool isDay;
    public bool isNight;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = daySkyBox;
        isDay = true;
        isNight = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDay && isNight == false)
        {
            print("[SKYBOX] Set to NIGHT");
            RenderSettings.skybox = nightSkyBox;
            isDay = false;
            isNight = true;
        } else if (isNight && isDay == false)
        {
            print("[SKYBOX] Set to DAY");
            RenderSettings.skybox = daySkyBox;
            isDay = true;
            isNight = false;
        }
        else
        {
            print("[SKYBOX] Switch glitched out resetting to night");
            RenderSettings.skybox = nightSkyBox;
            isDay = false;
            isNight = true;
        }
    }
}
