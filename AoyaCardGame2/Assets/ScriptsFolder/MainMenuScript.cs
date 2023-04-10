using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void Update()
    {
        
    }
    public void LoadBattleSceneNormal()
    {
        SceneManager.LoadScene("CardScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }

    public void ToGallery()
    {
        SceneManager.LoadScene("Gallery");
    }

    public void QuitGame()
    {
        Debug.Log("Game quit");
        Application.Quit();
    }
}
