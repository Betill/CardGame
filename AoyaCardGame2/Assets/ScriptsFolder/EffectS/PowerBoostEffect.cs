using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoostEffect : IEffect
{
    private CardPlace cardPlace;
    private Card card;

    public PowerBoostEffect(CardPlace cardPlace, Card card)
    {
        this.cardPlace = cardPlace;
        this.card = card;
    }

    public void applyEffect(ThisCard target)
    {
        card.AttackPower += cardPlace.cardsOnBF.Length;
    }
}
