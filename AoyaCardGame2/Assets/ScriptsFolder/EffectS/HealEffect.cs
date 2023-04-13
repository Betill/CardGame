using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : IEffect
{
    PlayerScript player;
    PlayerScript enemy;
    public int healAmount;

    public bool isGoodEffect => true;

    public HealEffect(PlayerScript player, PlayerScript enemy, int healAmount)
    {
        this.player = player;
        this.enemy = enemy;
        this.healAmount = healAmount;
    }

    public void applyEffect(ThisCard target)
    {
        if (target.IsPlayerCard)
            player.UpdateHP(healAmount);
        else
            enemy.UpdateHP(healAmount);
    }

    public string getDescription()
    {
        return GetType().Name;
    }
}
