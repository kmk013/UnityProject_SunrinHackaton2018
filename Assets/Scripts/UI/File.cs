using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class File : MonoBehaviour, IPointerClickHandler
{
    private RectTransform rectTransform;
    private Image image;

    public Sprite file1;
    public Sprite file2;

    public GameObject text1;

    public Agenda agenda;

    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();

        image.sprite = file1;
        rectTransform.sizeDelta = new Vector2(488, 566);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 mousePosition = Input.mousePosition;

        if (image.sprite == file1)
        {
            image.sprite = file2;
            text1.SetActive(true);
            rectTransform.sizeDelta = new Vector2(940, 601);
        }
        else if (image.sprite == file2)
        {
            if (mousePosition.x > rectTransform.anchoredPosition.x - rectTransform.sizeDelta.x / 2 && mousePosition.x < rectTransform.anchoredPosition.x &&
                mousePosition.y > rectTransform.anchoredPosition.y - rectTransform.sizeDelta.y / 2 && mousePosition.y < rectTransform.anchoredPosition.y + rectTransform.sizeDelta.y / 2)
            {
                image.sprite = file1;
                text1.SetActive(false);
                rectTransform.sizeDelta = new Vector2(488, 566);
                StartCoroutine(DisappearFile());
            }
        }
    }

    public IEnumerator ShowFile() {
        text1.GetComponent<Text>().text = "이번달 예산 : \n" + GameManager.Instance.money.ToString() +
            "원\n\n이번달 지지율 : " + GameManager.Instance.approvalRating.ToString() +
            "%\n\n\n이번달 범죄율 : " + GameManager.Instance.crimeRate.ToString() + "%";
        while(rectTransform.anchoredPosition.y > 415) {
            rectTransform.Translate(Vector3.down * Time.deltaTime * 100);
            yield return null;
        }
    }

    private IEnumerator DisappearFile() {
        image.sprite = file1;
	
        while(rectTransform.anchoredPosition.y < 1000) {
            rectTransform.Translate(Vector3.up * Time.deltaTime * 100);
            yield return null;
        }
        StartCoroutine(agenda.ShowAgenda());
    }
}