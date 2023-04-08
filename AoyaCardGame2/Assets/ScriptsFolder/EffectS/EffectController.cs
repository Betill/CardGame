using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public void applyCardEffects(Card card)
    {
        card.Effects.ForEach(effect => effect.applyEffect());
    }
}
