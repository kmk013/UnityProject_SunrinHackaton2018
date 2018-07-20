using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingBackground : MonoBehaviour
{

    private Image background;

    public List<Sprite> endingBackgrounds = new List<Sprite>();

    private void Start()
    {
        background = GetComponent<Image>();

        background.sprite = endingBackgrounds[GameManager.Instance.endingNum - 1];
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Destroy(GameManager.Instance.gameObject);
            SceneManager.LoadScene("StartScene");
        }
    }
}