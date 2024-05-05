using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject girl1;
    public GameObject girl2;
    public GameObject man;
    public Animator animator;
    public Avatar girl1Avatar;
    public Avatar girl2Avatar;
    public Avatar manAvatar;
    public AudioManager audioM;
    private int chosen;

    void Awake()
    {
       chosen = MainMenu.choice;
       audioM.Play("MainTheme");
    }

    void Start()
    {
        switch (chosen)
        {
            case 1:
                girl1.SetActive(true);
                animator.avatar = girl1Avatar;
                break;
            case 2:
                girl2.SetActive(true);
                animator.avatar = girl2Avatar;
                break;
            case 3:
                man.SetActive(true);
                animator.avatar = manAvatar;
                break;
        }
    }

    public void Restart()
    {
        PlayerHealth.dead = false;
        SceneManager.LoadScene("GameOver");
    }
}
