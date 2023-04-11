using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneEffect : IEffect
{
    public bool isGoodEffect => true;

    public void applyEffect(ThisCard target)
    {
        return;
    }
}
