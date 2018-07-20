using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Stamp : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform rectTransform;
    public RectTransform note;

    public bool isFollowMouse;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (isFollowMouse)
        {
            rectTransform.anchoredPosition = Input.mousePosition;

            if (Input.GetMouseButtonDown(1))
            {
                isFollowMouse = false;
                rectTransform.anchoredPosition = new Vector2(1220, 390);

                GetComponent<Image>().raycastTarget = true;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isFollowMouse = true;

        rectTransform.localScale = Vector3.one;
        GetComponent<Image>().raycastTarget = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isFollowMouse)
            rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = Vector3.one;
    }
}