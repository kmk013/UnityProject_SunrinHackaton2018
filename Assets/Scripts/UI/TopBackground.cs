using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TopBackground : MonoBehaviour, IPointerEnterHandler
{
    public Agenda agenda;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(agenda.isFollowMouse) {
            agenda.isFollowMouse = false;

            StartCoroutine(agenda.SubmitAgenda());
        }
    }
}
