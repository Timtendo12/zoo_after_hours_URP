using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySecondTrigger : MonoBehaviour
{
    public GameObject player;
    public enemyTriggerRandomizer enemyTriggerRandomizer;
    [Range(0, 100)]public float chanceOfSpawning;
    private bool shouldGenerate;
    public finishObjective FinishObjective;

    public Jumpscare Jumpscare;

    private void OnTriggerEnter(Collider other)
    {
        if (FinishObjective.missionFinished == false) return;
        Jumpscare.jumpscare();
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
