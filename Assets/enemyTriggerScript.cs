using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyTriggerScript : MonoBehaviour
{
    [Range(0, 100)]public float chanceOfSpawning;
    public GameObject target;
    public float radius;
    private Transform newTrigger;

    private void Start()
    {
        print("[TRIGGER: " + gameObject.name + "] has a " + chanceOfSpawning + "% of getting activated");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("[TRIGGER: " + gameObject.name + "] Player entered trigger -> generating point");
        //Instantiate(target, Random.insideUnitSphere * radius + ), quaternion.identity);
        GameObject enemySecondTrigger = Instantiate(target);
        enemySecondTrigger.transform.position = Random.insideUnitSphere * radius + transform.position;
        enemySecondTrigger.transform.position = new Vector3(enemySecondTrigger.transform.position.x, 0, enemySecondTrigger.transform.position.z);
    }
}
