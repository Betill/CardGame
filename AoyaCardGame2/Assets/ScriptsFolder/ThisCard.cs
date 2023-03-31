using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThisCard : MonoBehaviour
{
    public  List<Card> thisCard = new List<Card>();
   

    public Sprite thisSprite;
    public Image thatImage;

    public string cardName;
    public int ThisID;
    public int iD;
    public int attackPower;
    public int health;
    public int coolDown;

    public Text nameText;
    public Text attackText;
    public Text healthText;
    public Text cooldownText;


    public Sprite thisEffectSprite;
    public Image thatEffectImage;

    public bool IsCardBack;
  //   public static bool IsCardBackStatic;
   // CardBack CardBackScript;

    public GameObject Hand;
    public GameObject BattlePanel;
    public GameObject Border;
    public GameObject Target;
    public GameObject Enemy;

    public int NumbersOfCardsInDeck;
    public bool InBattleSpace;
    public bool activated;
/*
    public bool summoningSickness;
    public bool cantAttack;
    public bool canAttack;

    public static bool statictargeting;
    public static bool statictargetingEnemy;

    public bool targeting;
    public bool targetingEnemy;

    public bool onlyThisCardAttack;
    */


 /*   public void CanBeSummoned()
    {
        IsCardBack = true;
        InBattleSpace = true;

    }*/

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDataBase.cardList[ThisID];
        NumbersOfCardsInDeck = PlayerDeck.deckSize;

        activated = false;
        InBattleSpace = false;

      //  canAttack = false;
      //  summoningSickness = true;

        Enemy = GameObject.Find("EnemyGO(Clone)");


        
    }

   

    // Update is called once per frame
    void Update()

        
    {
        Hand= GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent )
        {
            IsCardBack = false;
        }
        BattlePanel = GameObject.Find("Panel");
        if (this.transform.parent == BattlePanel.transform  )
        {
            gameObject.GetComponent<DragCard>().enabled = false;
        }
        iD = thisCard[0].ID;
        cardName = thisCard[0].CardName ;
        attackPower = thisCard[0].AttackPower ;
        health  = thisCard[0].Health ;
       coolDown  = thisCard[0].CoolDown;

        thisSprite = thisCard[0].ThisImage;
        thisEffectSprite = thisCard[0].EffectImage;


       nameText.text = "" +cardName;
        attackText.text = "" + attackPower.ToString ();
        healthText.text = "" + health.ToString ();
        cooldownText.text = "" +  coolDown.ToString () ;

        thatImage.sprite = thisSprite;
        thatEffectImage.sprite = thisEffectSprite;

      //  IsCardBackStatic = IsCardBack;
        // CardBackScript.UpdateCard(IsCardBack);

        if (this.tag =="Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[NumbersOfCardsInDeck -1];

            NumbersOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
           IsCardBack = false;
            this.tag = "InHand";
        }

     


    }




}
