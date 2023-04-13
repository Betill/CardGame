using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnsControllerUI : MonoBehaviour
{
    public GameObject PlayerEndTurnButton;

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
            PlayerEndTurnButton.transform.GetChild(0).gameObject.SetActive(true);
            //CurrentTurnText.text = "Your Turn";
        }
        else
        {
            PlayerEndTurnButton.transform.GetChild(0).gameObject.SetActive(false);
            //CurrentTurnText.text = "Enemy Turn";
        }

        TurnCountText.text = turnsCount.ToString();
    }

    public void EndTurnText()
    {

    }
}
