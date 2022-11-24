using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyTriggerRandomizer : MonoBehaviour
{
    public List<Transform> children;
    public bool shouldGenerate;
    

    private void Start()
    {
        children = new List<Transform>();
            foreach (Transform tran in transform)
            {
                children.Add(tran);
            }

            shouldGenerate = true;
        generateTriggers();
           
    }

    private void Update()
    {
        if (!shouldGenerate) return;
        generateTriggers();
    }

    public void generateTriggers()
    {
        shouldGenerate = false;
        foreach (var trigger in children)
        {
            var rand = Random.Range(0, 100);
            if (rand < trigger.GetComponent<enemyTriggerScript>().chanceOfSpawning)
            {
                trigger.gameObject.SetActive(true);
            } else trigger.gameObject.SetActive(false);
        }
    }
}
