using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFromHandEffect : IEffect
{
    private Card card;
    //Reference to the enemy (not card)

    public AttackFromHandEffect(Card card)
    {
        this.card = card;
    }

    public void applyEffect(ThisCard target = null)
    {
        //Reduce enemy HP
        Debug.Log("The card attacked the enemy");
    }
}
