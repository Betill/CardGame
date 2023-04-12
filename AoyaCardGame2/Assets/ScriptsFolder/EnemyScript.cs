using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public RectTransform
        handPanel,
        robotPanel,
        humanPanel;

    public ThisCard[] cardsOnRobotBF => robotPanel.transform.GetComponentsInChildren<ThisCard>();
    public ThisCard[] cardsOnHumanBF => humanPanel.transform.GetComponentsInChildren<ThisCard>();

    public PlayerScript 
        robotScript, 
        playerScript;

    private float lastAction;
    private float waitingTime;

    [Tooltip("Difficulty from 0 to 100")]
    public float difficulty = 50f;

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
        waitingTime = .1f + Random.value * 2f;
    }

    private void MakeMove()
    {
        var randomMove = Random.Range(0, 100) > difficulty;
        if (randomMove) {
            MakeRandomMove();
        } else {
            var hand = handPanel.GetComponentsInChildren<ThisCard>().ToList();
            var myCards = cardsOnRobotBF.ToList();
            var enemyCards = cardsOnHumanBF.ToList();

            // first get the battlefield full
            if (myCards.Count < 4 && hand.Count > 0) {
                PlayCard(hand[0]);
                return;
            }

            // try to heal ourselves when less than 20 hp
            if (robotScript.CurrentHP < 20) {
                myCards.AddRange(hand);
                foreach (var c in myCards) {
                    if (c.thisCard.CardName == "Healer" && !c.EffectUsed) {
                        c.EffectUsed = true;
                        c.thisCard.Effects.ForEach(e => e.applyEffect(c));
                        return;
                    }
                }
            }

            // random effect @20% chance
            if (Random.value < .4f) {
                if (cardsOnRobotBF.Length > 0) {
                    ThisCard card = cardsOnRobotBF[Random.Range(0, cardsOnRobotBF.Length)];
                    IEffect effect = card.thisCard.Effects[Random.Range(0, card.thisCard.Effects.Count)];
                    if (card.activated && !card.EffectUsed) {
                        card.EffectUsed = true;
                        card.thisCard.Effects.ForEach(e => e.applyEffect(
                            effect.isGoodEffect ? card : cardsOnHumanBF[Random.Range(0, cardsOnHumanBF.Length)]
                        ));
                    } else waitingTime = 0f;
                } else waitingTime = 0f;
            }

            // sort enemy cards after attack power, so we know who is the biggest problem
            enemyCards.Sort((a, b) => b.thisCard.AttackPower - a.thisCard.AttackPower);
            var strongest = enemyCards.Count > 0 ? enemyCards[0] : null;
            if (strongest == null || strongest.thisCard.AttackPower < 3) {
                foreach (var c in myCards) {
                    if (ThisCard.CanAttack(c) && c.thisCard.AttackPower > 0) {
                        c.Attack(playerScript);
                        return;
                    }
                }
            } else {
                foreach (var c in myCards) {
                    if (ThisCard.CanAttack(c) && c.thisCard.AttackPower > 0) {
                        c.Attack(strongest);
                        return;
                    }
                }
            }

            TurnsController.instance.NextTurn();
        }
    }

    private void MakeRandomMove()
    {
        switch (Random.Range(0, 5)) {
            case 0:
                if (robotPanel.childCount < 4) {
                    var nextCard = handPanel.GetChild(Random.Range(0, handPanel.childCount));
                    if (nextCard != null) {
                        PlayCard(nextCard.GetComponent<ThisCard>()); //smart move!
                    } else waitingTime = 0f;
                } else waitingTime = 0f;
                break;
            case 1:
                if (cardsOnRobotBF.Length > 0 && cardsOnHumanBF.Length > 0) {
                    ThisCard card = cardsOnRobotBF[Random.Range(0, cardsOnRobotBF.Length)];
                    if (ThisCard.CanAttack(card)) {
                        card.Attack(cardsOnHumanBF[Random.Range(0, cardsOnHumanBF.Length)]);
                    } else waitingTime = 0f;
                } else waitingTime = 0f;
                break;
            case 2:
                if (cardsOnRobotBF.Length > 0) {
                    ThisCard card = cardsOnRobotBF[Random.Range(0, cardsOnRobotBF.Length)];
                    if (ThisCard.CanAttack(card)) {
                        card.Attack(playerScript);
                    } else waitingTime = 0f;
                } else waitingTime = 0f;
                break;
            case 3:
                if (cardsOnRobotBF.Length > 0) {
                    ThisCard card = cardsOnRobotBF[Random.Range(0, cardsOnRobotBF.Length)];
                    IEffect effect = card.thisCard.Effects[Random.Range(0, card.thisCard.Effects.Count)];
                    if (card.activated && !card.EffectUsed) {
                        card.EffectUsed = true;
                        card.thisCard.Effects.ForEach(e => e.applyEffect(
                            effect.isGoodEffect ? card : cardsOnHumanBF[Random.Range(0, cardsOnHumanBF.Length)]
                        ));
                    } else waitingTime = 0f;
                } else waitingTime = 0f;
                break;
            case 4:
                TurnsController.instance.NextTurn();
                break;
            default:
                TurnsController.instance.NextTurn();
                break;
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
