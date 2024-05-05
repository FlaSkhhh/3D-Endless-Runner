using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public Animator fadeAnim;
    public AudioManager audioM;
    public GameObject manager;
    public CharacterController controller;
    public static bool dead = false;

    void OnTriggerEnter(Collider col)
    {
        if (col != null)
        {
            if (col.tag == "Obstacle")
            {
                ObstacleSpeed.instance.speed = 0f;
                animator.SetTrigger("Death");
                dead = true;
                GetComponent<PlayerMovement>().enabled = false;
                Invoke("Restart", 3f);
                switch (MainMenu.choice)
                {
                    case 1:
                        audioM.Play("DeathF2");
                        break;
                    case 2:
                        audioM.Play("DeathF");
                        break;
                    case 3:
                        audioM.Play("DeathM");
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void Update()
    {
        if (dead)
        {
            controller.Move(new Vector3(0f, -5f, 0f)*Time.deltaTime);
            ObstacleSpeed.instance.roll=true;
        }
    }

    void Restart()
    {
        manager.GetComponent<GameManager>().Restart();
    }

    void Fade()
    {
        fadeAnim.SetTrigger("Fade");
    }
}
