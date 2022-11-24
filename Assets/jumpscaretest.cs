using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscaretest : MonoBehaviour

{

    public Jumpscare Jumpscare;

    private void OnTriggerEnter(Collider other)
    {
        Jumpscare.jumpscare();
    }
}
