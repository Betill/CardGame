using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    public bool isGoodEffect { get; }

    public void applyEffect(ThisCard target = null);
}
