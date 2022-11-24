using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyTriggerScript : MonoBehaviour
{
    [Range(0, 100)]public float chanceOfSpawning;
    public List<Transform> children;
    public bool canGenerate;

    private void Start()
    {
        canGenerate = true;
        print("[TRIGGER: " + gameObject.name + "] has a " + chanceOfSpawning + "% of getting activated");
        children = new List<Transform>();
        foreach (Transform tran in transform)
        {
            children.Add(tran);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canGenerate) return;
        foreach (var trigger in children)
        {
            var rand = Random.Range(0, 100);
            if (rand < trigger.GetComponent<enemySecondTrigger>().chanceOfSpawning){
                trigger.gameObject.SetActive(true);
            } else trigger.gameObject.SetActive(false);
        }
        canGenerate = false;
    }


    void checkGenerator()
    {
        new Timer();
    }
}
