using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnsController : MonoBehaviour
{
    public int TurnsCount = 0;
    public int CurrentTurn;

    public PlayerDeck PlayerDeck;
    public PlayerDeck EnemyDeck;
    private PlayerDeck CurrentDeck;

    public CardPlace PlayerBattleField;
    public CardPlace EnemyBattleField;
    private CardPlace CurrentBattleField;

    public static UnityAction<int, int> OnBeginTurn;
    public static UnityAction<int> OnEndTurn;


    private void Start()
    {
        //Choose random turn no begin (player or enemy)
        //Wait for cards to be dealt before playing
        PlayerDeck.DrawCard(5);
        EnemyDeck.DrawCard(5);

        CurrentTurn = 0;
        OnBeginTurn?.Invoke(CurrentTurn, TurnsCount);
    }

    public void NextTurn()
    {
        EndTurn();
        BeginTurn();
    }

    private void BeginTurn()
    {
        CurrentDeck = CurrentTurn == 0 ? PlayerDeck : EnemyDeck;
        CurrentBattleField = CurrentTurn == 0 ? PlayerBattleField : EnemyBattleField;

        CurrentDeck.DrawCard(1);

        OnBeginTurn?.Invoke(CurrentTurn, TurnsCount);
    }

    private void EndTurn()
    {
        if(CurrentBattleField != null)
        {
            ThisCard[] cardsOnBF = CurrentBattleField.cardsOnBF;
            foreach (ThisCard card in cardsOnBF)
            {
                card.UpdateCooldown(-1);
            }
        }
        
        CurrentTurn = (CurrentTurn + 1) % 2;
        TurnsCount++;
        OnEndTurn?.Invoke(CurrentTurn);
    }


}
