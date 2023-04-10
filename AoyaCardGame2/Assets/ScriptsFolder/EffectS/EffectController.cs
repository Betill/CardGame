using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public void applyCardEffects(Card card)
    {
        // add target of each card here. source it in some way to get the current player for example.
        // target is of type ThisCard, so if we have a DrawCards or Heal effect, it will target the owner of ThisCard target,
        // a damage spell would target another ThisCard of the enemy, for example.
        card.Effects.ForEach(effect => effect.applyEffect());
    }
}
