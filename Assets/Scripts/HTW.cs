using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HTW : MonoBehaviour
{
    public GameObject htwBackground1;
    public GameObject htwBackground2;

    public GameObject htwLeftButton;
    public GameObject htwRightButton;

    public void LeftButton() {
        htwBackground1.SetActive(true);
        htwBackground2.SetActive(false);
        htwLeftButton.SetActive(false);
        htwRightButton.SetActive(true);
    }

    public void RightButton()
    {
        htwBackground1.SetActive(false);
        htwBackground2.SetActive(true);
        htwLeftButton.SetActive(true);
        htwRightButton.SetActive(false);
    }
}
