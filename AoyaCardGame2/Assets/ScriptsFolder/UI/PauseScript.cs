using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
      public bool IsPaused;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space ))
        {
            if (IsPaused )
            {
                ResumeGame();
            }
            else
            {
                StopGame();
            }

        }
    }
    public void ResumeGame()
    {

        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void StopGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.UnloadSceneAsync("CardScene");
        SceneManager.LoadScene("StartMenu");
        IsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
