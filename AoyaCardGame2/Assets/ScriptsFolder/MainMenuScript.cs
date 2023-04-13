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
        EnemyScript.difficulty = 60f;
        SceneManager.LoadScene("CardScene", LoadSceneMode.Single);
    }

    public void LoadBattleSceneHard()
    {
        EnemyScript.difficulty = 100f;
        SceneManager.LoadScene("CardScene", LoadSceneMode.Single);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
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
