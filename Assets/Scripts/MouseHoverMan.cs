using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHoverMan : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator man;

    public void OnPointerEnter(PointerEventData eventData)
    {
        man.SetBool("MouseOn", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        man.SetBool("MouseOn", false);
    }
}
