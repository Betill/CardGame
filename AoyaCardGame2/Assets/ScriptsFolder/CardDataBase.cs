using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase: MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    public PlayerScript playerScript, enemyScript;

    public void Awake()
    {
        List<IEffect> testEffects = new List<IEffect>();
        PlayerDeck playerDeck = GameObject.Find("PlayerDeck").GetComponent<PlayerDeck>();
        PlayerDeck enemyDeck = GameObject.Find("EnemyDeck").GetComponent<PlayerDeck>();
        CardPlace cardPlace = GameObject.Find("Panel").GetComponent<CardPlace>();
        TurnsController turnsController = GameObject.Find("TurnsController").GetComponent<TurnsController>();
        GraveyardController graveyard = GameObject.Find("Graveyard").GetComponent<GraveyardController>();


        List<IEffect> testEffects2 = new List<IEffect>();
        List<IEffect> noneEffects = new List<IEffect>();
        List<IEffect> healeffect = new List<IEffect>();
       
        Card card5 = new Card(5, "Speed Boost", 1, 2, 0, Resources.Load<Sprite>("SpeedBoostPixelImage"), Resources.Load<Sprite>("SpeedBoostEffectImage"), noneEffects );
        Card card6 = new Card(6, "Shield", 1, 6, 4, Resources.Load<Sprite>("ShieldPixelImage"), Resources.Load<Sprite>("ShieldEffectImage"), noneEffects );
        Card card7 = new Card(7, "Healer", 0, 4, 2, Resources.Load<Sprite>("HealerPixelImage"), Resources.Load<Sprite>("HealerEffectImage"), healeffect );
        Card card8 = new Card(8, "Power Boost", 3, 2, 2, Resources.Load<Sprite>("PowerBoostPixelImage"), Resources.Load<Sprite>("PowerBoostEffectImage"), testEffects2);

        Card card11 = new Card(11, "Water", 1, 5, 2, Resources.Load<Sprite>("WaterPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);
        Card card12 = new Card(12, "Fire", 4, 1, 2, Resources.Load<Sprite>("FirePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);
        Card card13 = new Card(13, "The Beast", 6, 1, 3, Resources.Load<Sprite>("TheBeastPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);
        Card card14 = new Card(14, "Saber", 6, 4, 5, Resources.Load<Sprite>("SaberPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);
        Card card15 = new Card(15, "Hammer", 5, 5, 5, Resources.Load<Sprite>("HammerPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);

        Card card17 = new Card(17, "Lance", 4, 3, 3, Resources.Load<Sprite>("LancePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);
        Card card18 = new Card(18, "Warrior", 5, 5, 4, Resources.Load<Sprite>("WarriorPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);
        Card card19 = new Card(19, "Mage", 6, 3, 4, Resources.Load<Sprite>("MagePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), noneEffects);

        card8.Effects.Add(new PowerBoostEffect(cardPlace, card8));

        card5.Effects.Add(new NoneEffect());
        card6.Effects.Add(new NoneEffect());
        card7.Effects.Add(new HealEffect (playerScript, enemyScript, 5));
        card11.Effects.Add(new NoneEffect());
        card12.Effects.Add(new NoneEffect());
        card13.Effects.Add(new NoneEffect());
        card14.Effects.Add(new NoneEffect());
        card15.Effects.Add(new NoneEffect());
        card17.Effects.Add(new NoneEffect());
        card18.Effects.Add(new NoneEffect());
        card19.Effects.Add(new NoneEffect());

        Card returnCard = new Card(10, "Return", 3, 1, 4, Resources.Load<Sprite>("ReturnFromGraveyardPixelImage"), Resources.Load<Sprite>("ReturnFromGraveyardEffectImage"), noneEffects);
        returnCard.Effects = new List<IEffect>();
        returnCard.Effects.Add(new ReturnFromGraveyardEffect(returnCard, graveyard));
        cardList.Add(returnCard);

        Card card2 = new Card(2, "Surprise", 2, 1, 1, Resources.Load<Sprite>("SurprisePixelImage"), Resources.Load<Sprite>("SurpriseEffectImage"), noneEffects);
        card2.Effects.Add(new AttackFromHandEffect(card2));
        cardList.Add(card2);


        cardList.Add(new Card(0, "Crystal", 0, 1,1, Resources.Load <Sprite >("CrystalPixelImage"),Resources.Load<Sprite>("AccelationEffectImage"), 
            new List<IEffect>() { new SkipTurnsEffect(TurnsController.instance, 1) }));
        cardList.Add(new Card(1, "Pure Crystal", 0, 1, 2,Resources.Load<Sprite>("PureCrystalPixelImage"), Resources.Load<Sprite>("BigAccelationEffectImage"),
            new List<IEffect>() { new SkipTurnsEffect(TurnsController.instance, 2) }));
        cardList.Add(new Card(3, "Refill", 1, 1, 2, Resources.Load<Sprite>("RefillPixelImage"), Resources.Load<Sprite>("RefillEffectImage"),
            new List<IEffect>() { new DrawCardsEffect(playerDeck, enemyDeck, 1) }));
        cardList.Add(new Card(4, "Magnifier", 1, 1, 3,Resources.Load<Sprite>("MagnifierPixelImage"), Resources.Load<Sprite>("MagnifierEffectImage"),
            new List<IEffect>() { new DrawCardsEffect(playerDeck, enemyDeck, 2) }));

        cardList.Add(card5 );
        cardList.Add(card6);
        cardList.Add(card7);
         //  cardList.Add(new Card(5, "Speed Boost", 1, 2, 0,Resources.Load<Sprite>("SpeedBoostPixelImage"), Resources.Load<Sprite>("SpeedBoostEffectImage"), testEffects)); //none
        //  cardList.Add(new Card(6, "Shield", 1, 6, 4,Resources.Load<Sprite>("ShieldPixelImage"), Resources.Load<Sprite>("ShieldEffectImage"), testEffects));//none

      //  cardList.Add(new Card(7, "Healer", 0, 4, 2,Resources.Load<Sprite>("HealerPixelImage"), Resources.Load<Sprite>("HealerEffectImage"), testEffects));
        cardList.Add(card8);

        //cardList.Add(new Card(8, "Power Boost", 3, 2, 2,Resources.Load<Sprite>("PowerBoostPixelImage"), Resources.Load<Sprite>("PowerBoostEffectImage"), testEffects));

        cardList.Add(new Card(9, "Double Attack", 2, 3, 2,Resources.Load<Sprite>("DoubleAttackPixelImage"), Resources.Load<Sprite>("DoubleAttackEffectImage"), noneEffects));
        //cardList.Add(new Card(10, "Return", 3, 1, 4,Resources.Load<Sprite>("ReturnFromGraveyardPixelImage"), Resources.Load<Sprite>("ReturnFromGraveyardEffectImage"), noneEffects));



        cardList.Add(card11);
        cardList.Add(card12);
        cardList.Add(card13);
        cardList.Add(card14);
        cardList.Add(card15);
        /*    cardList.Add(new Card(11, "Water", 1, 5, 2,Resources.Load<Sprite>("WaterPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none
           cardList.Add(new Card(12, "Fire", 4, 1, 2,Resources.Load<Sprite>("FirePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none
           cardList.Add(new Card(13, "The Beast", 6, 1, 3,Resources.Load<Sprite>("TheBeastPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none
           cardList.Add(new Card(14, "Saber", 6, 4, 5,Resources.Load<Sprite>("SaberPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none
           cardList.Add(new Card(15, "Hammer", 5, 5, 5,Resources.Load<Sprite>("HammerPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none */

        cardList.Add(new Card(16, "Discard!", 0, 1, 2,Resources.Load<Sprite>("DiscardPixelImage"), Resources.Load<Sprite>("DiscardEffectImage"), noneEffects));
        /* cardList.Add(new Card(17, "Lance", 4, 3, 3,Resources.Load<Sprite>("LancePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none
        cardList.Add(new Card(18, "Warrior", 5, 5, 4,Resources.Load<Sprite>("WarriorPixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none
        cardList.Add(new Card(19, "Mage", 6, 3, 4,Resources.Load<Sprite>("MagePixelImage"), Resources.Load<Sprite>("NoneEffectImage"), testEffects));//none

        */
        cardList.Add(card17);
        cardList.Add(card18);
        cardList.Add(card19);

    }
}
