using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySecondTrigger : MonoBehaviour
{
    public GameObject player;
    public enemyTriggerRandomizer enemyTriggerRandomizer;
    private bool shouldGenerate;
    private void OnTriggerEnter(Collider other)
    {
        print("[TRIGGER: " + gameObject.name + "] Player entered 2nd trigger -> Jumpscare");
    }

    private void Update()
    {
        /*var distance = Vector3.Distance(player.transform.position, transform.position);
        //print("PLAYER: " + player.transform.position + " TRIGGER: " + transform.position + " DISTANCE: " + distance);
        if (distance < 5)
        {
            print("JUMPSCARE");
        } else if (distance > 50)
        {
            print("Regenerate");
              enemyTriggerRandomizer.generateTriggers();
              Destroy(gameObject);
    */}
}
