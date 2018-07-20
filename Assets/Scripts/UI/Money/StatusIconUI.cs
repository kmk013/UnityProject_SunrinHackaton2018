using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StatusIconUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        content.SetActive(true);
        if (name.Equals("Money"))
            content.GetComponent<MoneyContentbarUI>().ShowBar();
        else if(name.Equals("Population"))
            content.GetComponent<PopulationContentBar>().ShowBar();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        content.SetActive(false);
    }
}