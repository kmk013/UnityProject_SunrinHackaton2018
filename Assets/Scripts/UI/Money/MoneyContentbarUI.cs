using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyContentbarUI : MonoBehaviour
{
    public Text taxText;
    public Text moneyText;

    public void ShowBar()
    {
        taxText.text = GameManager.Instance.tax.ToString() + "원";
        moneyText.text = GameManager.Instance.money.ToString() + "원";
    }
}