using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EffectSO :ScriptableObject 
{
   public  abstract void Effect(GameObject  GOCardWithEffect);
}

[CreateAssetMenu (fileName = "CrystalEffect", menuName ="Effects/AllEffects")]
class CrystalEffect : EffectSO
{
    
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// is activated
        {
            Transform CurrentTurnText = GOCardWithEffect.transform.Find("TurnCounterGO");
            TurnEnum textOfTurn = CurrentTurnText.GetComponent<TurnEnum>();
            textOfTurn.CurrentTurn += 1;
        }
   
    }
}

[CreateAssetMenu(fileName = "PureCrystalEffect", menuName = "Effects/AllEffects")]
class PureCrystalEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// is activated
        {
            Transform CurrentTurnText = GOCardWithEffect.transform.Find("TurnCounterGO");
            TurnEnum textOfTurn = CurrentTurnText.GetComponent<TurnEnum>();
            textOfTurn.CurrentTurn += 2;
        }
    }
}

[CreateAssetMenu(fileName = "SurpriseEffect", menuName = "Effects/AllEffects")]
class SurpriseEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (GOCardWithEffect .tag == "InHand")// and drop on enemy card zone
        {
            // 直接?少?人血量， ?????
            // enemy's blood minus this card's attack power and this card is destroyed from hand
        }
    }
}
[CreateAssetMenu(fileName = "RefillEffect", menuName = "Effects/AllEffects")]
class RefillEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// is activated
        {
            // draw(1);
        }
    }
}
[CreateAssetMenu(fileName = "MagnifierEffect", menuName = "Effects/AllEffects")]
class MagnifierEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// is activated and pile is more than 0 
        {
            // find card();
        }
    }

    public void FindCardFromPile()
    { 
        // find a card based on name and go to players hand 
    }
}

[CreateAssetMenu(fileName = "HealerEffect", menuName = "Effects/AllEffects")]
class HealerEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// player's blood is lower than max blood && is activated
        {
            // only heal to max blood
        }
    }
}

[CreateAssetMenu(fileName = "PowerBoostEffect", menuName = "Effects/AllEffects")]
class PowerBoostEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// is activated, gains power based on how many card is on players field, and i is not dynamite
        {

        }
    }
}

[CreateAssetMenu(fileName = "DoubleAttackEffect", menuName = "Effects/AllEffects")]
class DoubleAttackEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true) // is activated, 
        {
            // can atack twice in a turn
        }
    }
}

[CreateAssetMenu(fileName = "ReturnFromGraveyardEffect", menuName = "Effects/AllEffects")]
class ReturnFromGraveyardEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// its disposed
        {
            // a non vicible copy of it will be in hsnf
        }
        if (true)// cooldown is over
        {
            // copy can be seen
        }
    }
}

[CreateAssetMenu(fileName = "DiscardEffect", menuName = "Effects/AllEffects")]
class DiscardEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        if (true)// is activited, there's other cards (maybe also nonactivated?
        {
            // ask if player really want to remove that , if not then return 
            // remove selected card
        }
    }
}


[CreateAssetMenu(fileName = "NoneEffect", menuName = "Effects/AllEffects")]
class NoneEffect : EffectSO
{
    public override void Effect(GameObject GOCardWithEffect)
    {
        // does not contains effect 
    }
}

