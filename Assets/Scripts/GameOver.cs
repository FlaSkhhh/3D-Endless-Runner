using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Animator animator;
    public Animator pAnimator;
    public Avatar girl1Avatar;
    public Avatar girl2Avatar;
    public Avatar manAvatar;
    public GameObject girl1;
    public GameObject girl2;
    public GameObject man;
    private int chosen;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        chosen = MainMenu.choice;
    }

    void Start()
    {
        switch (chosen)
        {
            case 1:
                girl1.SetActive(true);
                pAnimator.avatar = girl1Avatar;
                break;
            case 2:
                girl2.SetActive(true);
                pAnimator.avatar = girl2Avatar;
                break;
            case 3:
                man.SetActive(true);
                pAnimator.avatar = manAvatar;
                pAnimator.SetBool("Female", false);
                break;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Invoke("Restart", 0.5f);
            animator.SetTrigger("Fade");
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Running");
    }
}
