using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable ]
public class Card 
{
    public int ID;
    public string CardName;
    public int AttackPower;
    public int Health;
    public int CoolDown;

    public Sprite ThisImage;
    public Sprite EffectImage;

    public Card() { }

    public Card(int ID, string CardName, int AttackPower, int Health, int CoolDown, Sprite ThisImage, Sprite EffectImage)
    {
        this.ID = ID;
        this.CardName = CardName;
        this.AttackPower = AttackPower;
        this.Health = Health;
        this.CoolDown  = CoolDown;
        this.ThisImage = ThisImage;
        this.EffectImage = EffectImage;
    }

}
