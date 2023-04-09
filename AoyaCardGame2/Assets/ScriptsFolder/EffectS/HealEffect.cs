using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : IEffect
{
    PlayerScript player;
    public int healAmount;

    public HealEffect(PlayerScript player, int healAmount)
    {
        this.player = player;
        this.healAmount = healAmount;
    }

    public void applyEffect()
    {
        player.UpdateHP(healAmount);
    }
}
