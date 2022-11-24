using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;using UnityEngine.UI;

public class fadeToBlack : MonoBehaviour

{
    public RawImage black;

    public bool fade;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (fade)
        {
            timer += Time.deltaTime;
            black.color = new Vector4(0,0,0,timer);
            if (timer >= 1)
            {
                timer = 1;
            }
        }

        if (!fade)
        {
            timer -= Time.deltaTime;
            black.color = new Vector4(0,0,0,timer);
            if (timer <= 0)
            {
                timer = 0;
            }
        }
    }
}
