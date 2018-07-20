using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AgendaEffectData
{
    public AgendaEffect agendaEffect;
    public int effectValue;
}

public enum AgendaType
{
    Common,
    Else,
}

public enum AgendaEffect
{
    IncreaseMoney,
    DecreaseMoney,
    IncreaseTax,
    DecreaseTax,
    IncreasePopulation,
    DecreasePopulation,
    IncreaseApprovalRating,
    DecreaseApprovalRating,
    IncreaseCrimeRate,
    DecreaseCrimeRate,
}

public enum InGameStatus
{
    FADEOUT,
    REPORT,
    AGENDA,
    FADEIN,
}

public class GameManager : SingleTon<GameManager>
{
    private int day = 1;

    public int money;          //자본
    public int tax;            //세금
    public int population;     //인구
    public int approvalRating; //지지율
    public int crimeRate;      //범죄율

    public Text dateText;

    public InGameStatus inGameStatus = InGameStatus.FADEOUT;

    public List<AgendaEffectData> receiveAgendaEffectDatas = new List<AgendaEffectData>();

    public int endingNum = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void ChangeStatusPerMonth()
    {
        dateText.text = (++day).ToString();

        money += population * tax;

        if (crimeRate >= 25)
            population -= population / 10;

        foreach (var i in receiveAgendaEffectDatas)
            SetAgendaEffectData(i);

        receiveAgendaEffectDatas.Clear();

        if (approvalRating <= 0)
            approvalRating = 0;
        else if (approvalRating >= 100)
            approvalRating = 100;

        if (crimeRate <= 0)
            crimeRate = 0;
        else if (crimeRate >= 100)
            crimeRate = 100;

        CheckEnding();
    }

    public void SetAgendaEffectData(AgendaEffectData agendaEffectData)
    {
        if (agendaEffectData.agendaEffect == AgendaEffect.IncreaseMoney)
            money += agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.DecreaseMoney)
            money -= agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.IncreaseTax)
            tax += agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.DecreaseTax)
            tax -= agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.IncreasePopulation)
            population += agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.DecreasePopulation)
            population -= agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.IncreaseApprovalRating)
            approvalRating += agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.DecreaseApprovalRating)
            approvalRating -= agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.IncreaseCrimeRate)
            crimeRate += agendaEffectData.effectValue;
        else if (agendaEffectData.agendaEffect == AgendaEffect.DecreaseCrimeRate)
            crimeRate -= agendaEffectData.effectValue;
    }

    public void CheckEnding() {
        if (approvalRating <= 0)
        {
            endingNum = 1;
            SceneManager.LoadScene("EndingScene");
        }
        else if(crimeRate >= 100) {
            endingNum = 2;
            SceneManager.LoadScene("EndingScene");
        } else if(day >= 48) {
            endingNum = 3;
            SceneManager.LoadScene("EndingScene");
        } else if(approvalRating >= 100) {
            endingNum = 4;
            SceneManager.LoadScene("EndingScene");
        } else if(money >= 2000000000) {
            endingNum = 5;
            SceneManager.LoadScene("EndingScene");
        }
    }
}