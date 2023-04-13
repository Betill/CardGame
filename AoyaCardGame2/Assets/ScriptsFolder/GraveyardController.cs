using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GraveyardController : MonoBehaviour
{
    [SerializeField] private List<Card> playerDiscardedCards = new List<Card>();
    [SerializeField] private List<Card> enemyDiscardedCards = new List<Card>();
    public static UnityAction<Card, bool> OnCardRemovedFromGraveyard;

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

    public Card RemoveCardFromGraveyard(int cardId, bool IsPlayer)
    {
        List<Card> discardedCards = IsPlayer ? playerDiscardedCards : enemyDiscardedCards;
        Card card = discardedCards.Find(card => card.ID == cardId);
        OnCardRemovedFromGraveyard?.Invoke(card, IsPlayer);
        return card;
    } 
}
