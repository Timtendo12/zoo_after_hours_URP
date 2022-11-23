using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyUIHider : MonoBehaviour
{
    public KeyBehaviour KeyBehaviour;
    public RawImage keyUI;
    private void OnTriggerEnter(Collider other)
    {
        //Hiding ui icon so it wont interfer with the bloom effect
        if (!KeyBehaviour.hasKey) return;
        keyUI.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!KeyBehaviour.hasKey) return;
        keyUI.gameObject.SetActive(true);
    }
}
