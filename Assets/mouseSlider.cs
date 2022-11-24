using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mouseSlider : MonoBehaviour
{
    public Slider mouseSens;
    public TextMeshProUGUI sensitivity;
    public float camSensitivity;

    // Update is called once per frame

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        sensitivity.text = mouseSens.value.ToString();
        camSensitivity = mouseSens.value * 100;
    }
}
