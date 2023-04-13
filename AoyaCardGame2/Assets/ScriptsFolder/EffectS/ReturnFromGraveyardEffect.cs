using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnFromGraveyardEffect : IEffect
{
    private Card card;
    private GraveyardController graveyardController;

    public bool isGoodEffect => true;

    public ReturnFromGraveyardEffect(Card card, GraveyardController graveyardController)
    {
        this.card = card;
        this.graveyardController = graveyardController;
    }

    public void applyEffect(ThisCard target = null)
    {
        graveyardController.RemoveCardFromGraveyard(card.ID, !target.IsPlayerCard);

    }

    public string getDescription()
    {
        return GetType().Name;
    }
}
