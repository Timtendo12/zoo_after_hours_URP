using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSVariable : MonoBehaviour
{
    public bool hasBeenJumpScared;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
