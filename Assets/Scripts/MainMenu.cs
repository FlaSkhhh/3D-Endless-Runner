using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
   public Animator girl;
   public Animator boy;
   public static int choice=0;
   public GameObject txt;
   //public Animator animator;
   private float count = 0f;

   void Start()
   {
        Cursor.lockState = CursorLockMode.None;
        txt.SetActive(false);
   }
   
   public void Play()
   {
       if (choice == 0)
       {
            txt.SetActive(true);
            return;
       }
       SceneChange();
       //animator.SetTrigger("Fade");
   }

   public void Quit()
   {
       Application.Quit();
   }

   public void GirlSelect()
   {
        choice = 1;
        count++;
        girl.SetBool("Selected", true);
        girl.SetBool("NotSelected", false);
        boy.SetBool("Selected", false);
        boy.SetBool("NotSelected", true);
        if (count >= 5)
        {
            choice = 2;
        }
   }

   public void ManSelect()
   {
        girl.SetBool("Selected", false);
        girl.SetBool("NotSelected", true);
        boy.SetBool("Selected", true);
        boy.SetBool("NotSelected", false);
        choice = 3;
   }

   void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}