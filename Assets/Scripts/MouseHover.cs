using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    public Animator girl;

    public void OnPointerEnter(PointerEventData eventData)
    {
        girl.SetBool("MouseOn", true);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        girl.SetBool("MouseOn", false);
    }
}
