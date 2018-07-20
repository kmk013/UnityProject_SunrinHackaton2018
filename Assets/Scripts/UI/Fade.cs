using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public File file;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();

        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Color color = image.color;
        while (color.a >= 0)
        {
            color.a -= Time.deltaTime;
            image.color = color;
            yield return null;
        }
        StartCoroutine(file.ShowFile());
    }

    public IEnumerator FadeIn()
    {
        Color color = image.color;
        while(color.a <= 1)
        {
            color.a += Time.deltaTime;
            image.color = color;
            yield return null;
        }
        GameManager.Instance.ChangeStatusPerMonth();
        StartCoroutine(FadeOut());
    }
}
