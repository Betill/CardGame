using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
  public void LoadBattleSceneNormal()
    {
        SceneManager.LoadScene("CardScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void ToGallery()
    {
        SceneManager.LoadScene("Gallery");
    }
}
