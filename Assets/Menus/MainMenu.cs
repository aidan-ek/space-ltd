using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button htpButton;
    public Button quitButton;
    public SpriteRenderer htpScreen;

    void Start() {
        playButton.onClick.AddListener(StartGame);
        htpButton.onClick.AddListener(HowToPlay);
        quitButton.onClick.AddListener(Quit);
    }

    void StartGame() {
        Debug.Log("level0");
        SceneManager.LoadScene("level0");
        
    }

    void HowToPlay() {
        if (htpScreen.enabled) {
            htpScreen.enabled = false;
        } else {
            htpScreen.enabled = true;
        }
    }

    void Quit() {
        Debug.Log("quit");
        Application.Quit();
        
    }

}
