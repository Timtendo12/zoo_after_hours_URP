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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        bgMusic.loop = true;
    }

    public void PlayGame()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        bgMusic.Stop();
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame()
    {
        bgMusic.Stop();
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
