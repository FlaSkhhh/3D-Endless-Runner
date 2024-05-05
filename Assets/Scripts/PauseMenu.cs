using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject player;
    public GameObject UI;
    public Slider Mslider;
    public Slider Sslider;
    public AudioManager audioM;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        audioM.MainVolume(0.5f);
        audioM.SFXVolume(1f);
        Mslider.value = 0.5f;
        Sslider.value = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlayerHealth.dead)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (isPaused)
        {
            audioM.MainVolume(Mslider.value);
            audioM.SFXVolume(Sslider.value);
        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
        Time.timeScale = 0;
        player.GetComponent<PlayerMovement>().enabled = false;
        UI.SetActive(true);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        Time.timeScale = 1;
        player.GetComponent<PlayerMovement>().enabled = true;
        UI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        isPaused = false;
    }
}