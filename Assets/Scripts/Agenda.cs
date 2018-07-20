using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class AgendaData
{
    public Sprite sprite;
    public string agendaText;
    public string agendaSubText;
    public List<AgendaEffectData> allowAgendaEffectDatas;
    public List<AgendaEffectData> refuseAgendaEffectDatas;
}

[System.Serializable] public class CommonAgendaData : AgendaData { }
[System.Serializable] public class PlusAgendaData : AgendaData { }

public class Agenda : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private RectTransform rectTransform;
    private Image image;

    public List<CommonAgendaData> commonAgendaDatas = new List<CommonAgendaData>();
    public List<PlusAgendaData> plusAgendaDatas = new List<PlusAgendaData>();
    public AgendaData targetAgendaData;

    public bool agendaOk;
    public bool isFollowMouse;

    public Stamp stamp;
    public RectTransform topBackgroundRect;
    public GameObject confirm;

    public Image detailImage;
    public Text detailText;
    public Text detailSubText;
    public GameObject settingTax;
    public Text settingTax_text;

    public Fade fade;

    private int agendaCnt = 0;
    private int resetTax = 1;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void AgendaSeal()
    {
        if (agendaCnt != 4)
        {
            if (agendaOk)
                foreach (var i in targetAgendaData.allowAgendaEffectDatas)
                    GameManager.Instance.receiveAgendaEffectDatas.Add(i);
            else if (!agendaOk)
                foreach (var i in targetAgendaData.refuseAgendaEffectDatas)
                    GameManager.Instance.receiveAgendaEffectDatas.Add(i);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isFollowMouse)
        {
            rectTransform.anchoredPosition = Input.mousePosition;
            image.raycastTarget = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (stamp.isFollowMouse)
        {
            agendaOk = true;

            stamp.isFollowMouse = false;
            stamp.rectTransform.anchoredPosition = new Vector2(1220, 390);

            stamp.GetComponent<Image>().raycastTarget = true;

            Instantiate(confirm, transform.GetChild(0).transform);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        isFollowMouse = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isFollowMouse = true;
    }

    public IEnumerator SubmitAgenda()
    {
        while (rectTransform.anchoredPosition.y < 1015)
        {
            rectTransform.Translate(Vector3.up * Time.deltaTime * 100);
            yield return null;
        }

        if (agendaCnt <= 4)
            AgendaSeal();
        else
            GameManager.Instance.tax = resetTax;

        if (agendaOk)
        {
            Destroy(transform.GetChild(0).transform.GetChild(0).gameObject);
            agendaOk = false;
        }
        if (agendaCnt <= 4)
            StartCoroutine(ShowAgenda());
        else
        {
            StartCoroutine(fade.FadeIn());

            agendaCnt = 0;
        }
    }

    public IEnumerator ShowAgenda()
    {
        if (agendaCnt >= 0 && agendaCnt <= 2)
            targetAgendaData = commonAgendaDatas[agendaCnt];
        else if (agendaCnt == 3)
            targetAgendaData = plusAgendaDatas[Random.Range(0, plusAgendaDatas.Count)];
        else if (agendaCnt == 4)
            targetAgendaData = null;
        ShowDetailAgenda();

        agendaCnt++;

        rectTransform.anchoredPosition = new Vector2(720, rectTransform.anchoredPosition.y);

        while (rectTransform.anchoredPosition.y > 430)
        {
            rectTransform.Translate(Vector3.down * Time.deltaTime * 100);
            yield return null;
        }
    }

    private void ShowDetailAgenda()
    {
        if (agendaCnt != 4)
        {
            if (targetAgendaData.sprite != null)
                detailImage.sprite = targetAgendaData.sprite;
            else
            {
                detailImage.sprite = null;
                Color color = detailImage.color;
                color.a = 0;
                detailImage.color = color;
            }
            detailText.text = targetAgendaData.agendaText;
            detailSubText.text = targetAgendaData.agendaSubText;
        }
        else {
            detailText.text = "세금 설정";
            detailSubText.text = "다음달의 세금을 어떻게 걷을지 설정";
            settingTax.SetActive(true);
            SettingTaxText();
        }
    }

    public void PlusTax()
    {
        if (resetTax <= 8)
            resetTax++;
        SettingTaxText();
    }

    public void MinusTax()
    {
        if (resetTax >= 2)
            resetTax--;
        SettingTaxText();
    }

    private void SettingTaxText() {
        settingTax_text.text = resetTax.ToString();
    }
}