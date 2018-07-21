using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneButtonManager : MonoBehaviour {

    public GameObject htw;

    private void Awake()
    {
        Screen.SetResolution(1440, 1080, false);
    }

    public void GameStartButton() {
        SceneManager.LoadScene("GameScene");   
    }

    public void HowToPlayButton() {
        htw.SetActive(true);
    }

    public void ExitButton()
    {
        htw.SetActive(false);
    }
}
