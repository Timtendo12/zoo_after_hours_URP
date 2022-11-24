using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterScript : MonoBehaviour
{
    public float spawnX;
    public float spawnY;
    public float spawnZ;
    public fadeToBlack fader;

    public GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        fader.fade = false;
        StartCoroutine(water());
    }


    IEnumerator water()
    {
        fader.fade = true;
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(spawnX, spawnY, spawnZ);
        yield return new WaitForSeconds(1);
        fader.fade = false;
        
    }
}
