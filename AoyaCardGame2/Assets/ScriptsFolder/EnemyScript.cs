using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public RectTransform
        handPanel,
        robotPanel,
        humanPanel;

    private float lastAction;
    private float waitingTime;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (TurnsController.instance.CurrentTurn == 0)
            return;

        if (lastAction + waitingTime > Time.time)
            return;        

        MakeMove();

        lastAction = Time.time;
        waitingTime = 1f + Random.value * 3f;
    }

    private void MakeMove()
    {
        var tilted = robotPanel.childCount == 4 || Random.value > .5f;
        if (tilted) {
            TurnsController.instance.NextTurn();
        }

        var nextCard = handPanel.GetChild(Random.Range(0, handPanel.childCount));
        if (nextCard != null) {
            PlayCard(nextCard.GetComponent<ThisCard>()); //smart move!
        }
    }

    private void PlayCard(ThisCard card)
    {
        if (robotPanel.childCount >= 4)
            return;

        card.transform.parent = robotPanel;
    }

    private List<ThisCard> GetCardsInHand()
    {
        List<ThisCard> hand = new List<ThisCard>();
        foreach (var card in handPanel) {
            hand.Add((card as GameObject).GetComponent<ThisCard>());
        }
        return hand;
    }
}
