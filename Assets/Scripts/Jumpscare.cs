using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public GameObject player;
    public GameObject jsPlayer;
    public 
    
    void jumpscare()
    {
        jsPlayer.SetActive(true);
        player.SetActive(false);
        
    }
}
