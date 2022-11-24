using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public TextMeshProUGUI sm_y;
    public TextMeshProUGUI sm_x;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public GameObject MouseSliderObj;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MouseSliderObj = GameObject.Find("mouseSlider");
        mouseSlider ms = MouseSliderObj.GetComponent<mouseSlider>();


        sensX = ms.camSensitivity;
        sensY = ms.camSensitivity;


        sm_x.text = sensX.ToString();
        sm_y.text = sensY.ToString();
    }

    private void Update()
    {
        // get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}