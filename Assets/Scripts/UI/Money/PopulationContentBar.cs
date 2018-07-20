using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationContentBar : MonoBehaviour
{
    public Text populationText;

    public void ShowBar()
    {
        populationText.text = GameManager.Instance.population.ToString() + "명";
    }
}