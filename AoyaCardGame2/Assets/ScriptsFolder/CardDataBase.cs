using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase: MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    public void Awake()
    {
        List<IEffect> testEffects = new List<IEffect>();
        PlayerDeck playerDeck = GameObject.Find("PlayerDeck").GetComponent<PlayerDeck>();
        testEffects.Add(new DrawCardsEffect(playerDeck, 2));


        cardList.Add(new Card(0, "Crystal", 0, 1,1, Resources.Load <Sprite >("CrystalPixelImage"),Resources.Load<Sprite>("AccelationEffectImage"),testEffects)) ;
        cardList.Add(new Card(1, "Pure Crystal", 0, 1, 2,Resources.Load<Sprite>("PureCrystalPixelImage"), Resources.Load<Sprite>("BigAccelationEffectImage"), testEffects));
        cardList.Add(new Card(2, "Surprise", 2, 1, 1,Resources.Load <Sprite>("SurprisePixelImage"), Resources.Load<Sprite>("SurpriseEffectImage"), testEffects));
        cardList.Add(new Card(3, "Refill", 1, 1, 2, Resources.Load<Sprite>("RefillPixelImage"), Resources.Load<Sprite>("RefillEffectImage"), testEffects));
        cardList.Add(new Card(4, "Magnifier", 1, 1, 3,Resources.Load<Sprite>("MagnifierPixelImage"), Resources.Load<Sprite>("MagnifierEffectImage"), testEffects));
        
           cardList.Add(new Card(5, "Speed Boost", 1, 2, 0,Resources.Load<Sprite>("SpeedBoostPixelImage"), Resources.Load<Sprite>("SpeedBoostEffectImage"), testEffects));
          cardList.Add(new Card(6, "Shield", 1, 6, 4,Resources.Load<Sprite>("ShieldPixelImage"), Resources.Load<Sprite>("ShieldEffectImage"), testEffects));
          cardList.Add(new Card(7, "Healer", 0, 4, 2,Resources.Load<Sprite>("HealerPixelImage"), Resources.Load<Sprite>("HealerEffectImage"), testEffects));
          cardList.Add(new Card(8, "Power Boost", 3, 2, 2,Resources.Load<Sprite>("PowerBoostPixelImage"), Resources.Load<Sprite>("PowerBoostEffectImage"), testEffects));
          cardList.Add(new Card(9, "Double Attack", 2, 3, 2,Resources.Load<Sprite>("DoubleAttackPixelImage"), Resources.Load<Sprite>("DoubleAttackEffectImage"), testEffects));
          cardList.Add(new Card(10, "Return", 3, 1, 4,Resources.Load<Sprite>("ReturnFromGraveyardPixelImage"), Resources.Load<Sprite>("ReturnFromGraveyardEffectImage"), testEffects));
         cardList.Add(new Card(11, "Water", 1, 5, 2,Resources.Load<Sprite>("WaterPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
           cardList.Add(new Card(12, "Fire", 4, 1, 2,Resources.Load<Sprite>("FirePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
           cardList.Add(new Card(13, "The Beast", 6, 1, 3,Resources.Load<Sprite>("TheBeastPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
           cardList.Add(new Card(14, "Saber", 6, 4, 5,Resources.Load<Sprite>("SaberPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
           cardList.Add(new Card(15, "Hammer", 5, 5, 5,Resources.Load<Sprite>("HammerPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
           cardList.Add(new Card(16, "Discard!", 0, 1, 2,Resources.Load<Sprite>("DiscardPixelImage"), Resources.Load<Sprite>("DiscardEffectImage"), testEffects));
         cardList.Add(new Card(17, "Lance", 4, 3, 3,Resources.Load<Sprite>("LancePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
         cardList.Add(new Card(18, "Warrior", 5, 5, 4,Resources.Load<Sprite>("WarriorPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
         cardList.Add(new Card(19, "Mage", 6, 3, 4,Resources.Load<Sprite>("MagePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));
          
    }
}
