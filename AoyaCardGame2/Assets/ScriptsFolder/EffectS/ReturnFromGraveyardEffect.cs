using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromGraveyardEffect : IEffect
{
    private Card card;
    private PlayerDeck playerDeck;

    public ReturnFromGraveyardEffect(Card card, PlayerDeck playerDeck)
    {
        this.card = card;
        this.playerDeck = playerDeck;
    }

    public void applyEffect(ThisCard target = null)
    {
        playerDeck.AddCardToHand(card);
    }
}
