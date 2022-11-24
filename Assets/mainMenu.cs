using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour

{
    public AudioSource bgMusic;

    private void Start()
    {
        bgMusic.Play();
        bgMusic.loop = true;
    }

    public void PlayGame()
    {
        bgMusic.Stop();
        SceneManager.LoadScene("Developer_Tim");
    }

    public void QuitGame()
    {
        bgMusic.Stop();
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
