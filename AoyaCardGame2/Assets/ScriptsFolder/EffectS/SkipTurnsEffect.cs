using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTurnsEffect : IEffect
{
    private TurnsController turnsController;
    private int numberOfTurnsToSkip;

    public bool isGoodEffect => true;

    public SkipTurnsEffect(TurnsController turnsController, int numberOfTurnsToSkip)
    {
        this.turnsController = turnsController;
        this.numberOfTurnsToSkip = numberOfTurnsToSkip;
    }

    public void applyEffect(ThisCard target)
    {
        for(int i = 0; i < numberOfTurnsToSkip; i++)
        {
            turnsController.NextTurn();
            turnsController.NextTurn();
        }
    }
}
