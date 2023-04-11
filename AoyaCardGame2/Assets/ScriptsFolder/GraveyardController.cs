using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardController : MonoBehaviour
{
    [SerializeField] private List<Card> playerDiscardedCards = new List<Card>();
    [SerializeField] private List<Card> enemyDiscardedCards = new List<Card>();

    public void AddCardToGraveyard(Card card, bool IsPlayer)
    {
        if (IsPlayer)
        {
            playerDiscardedCards.Add(card);
        }
        else
        {
            enemyDiscardedCards.Add(card);
        }
    }

    public Card RemoveCardToGraveyard(int cardId, bool IsPlayer)
    {
        List<Card> discardedCards = IsPlayer ? playerDiscardedCards : enemyDiscardedCards;
        return discardedCards.Find(card => card.ID == cardId);
    }
}
