using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnsControllerUI : MonoBehaviour
{
    public Button PlayerEndTurnButton;
    public Button EnemyEndTurnButton;

    public Text CurrentTurnText;
    public Text TurnCountText;

    private void Awake()
    {
        TurnsController.OnBeginTurn += BeginTurnText;
    }

    public void BeginTurnText(int currentTurn, int turnsCount)
    {
        if(currentTurn == 0)
        {
            PlayerEndTurnButton.gameObject.SetActive(true);
            EnemyEndTurnButton.gameObject.SetActive(false);
            CurrentTurnText.text = "Your Turn";
        }
        else
        {
            PlayerEndTurnButton.gameObject.SetActive(false);
            EnemyEndTurnButton.gameObject.SetActive(true);
            CurrentTurnText.text = "Enemy Turn";
        }

        TurnCountText.text = turnsCount.ToString();
    }

    public void EndTurnText()
    {

    }
}
