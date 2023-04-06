using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThisCard : MonoBehaviour, IPointerClickHandler 
{
    public List<Card> thisCard = new List<Card>();

    public Sprite thisSprite;
    public Image thatImage;
    public Image Border;

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
    public bool IsPlayerCard;
  //   public static bool IsCardBackStatic;
   // CardBack CardBackScript;

    public GameObject Hand;
    public GameObject BattlePanel;
    public GameObject Target;
    public GameObject Enemy;

    public int playedOnTurn;
    public int NumbersOfCardsInDeck;
    public bool InBattleSpace;
    public bool activated;

    public bool Selected;
    public bool onBattleField;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onBattleField)
        {
            DeselectAllCards();
            if (activated) {
                Selected = true;
            }
        }
    }

   
    void Start()
    {
        thisCard[0] = CardDataBase.cardList[ThisID];
        NumbersOfCardsInDeck = PlayerDeck.deckSize;

        activated = false;
        InBattleSpace = false;

        Enemy = GameObject.Find("EnemyGO(Clone)");       
    }

    public void Play(int cardIdr)
    {
        
    }

    // Update is called once per frame
    void Update()        
    {
        if (this.transform.parent == Hand.transform)
        {
            if (IsPlayerCard) {
                IsCardBack = false;
            } else {
                IsCardBack = true;
            }
        }

        BattlePanel = GameObject.Find("Panel");
        if (this.transform.parent == BattlePanel.transform  )
        {
            gameObject.GetComponent<DragCard>().enabled = false;
        }

        iD = thisCard[0].ID;
        cardName = thisCard[0].CardName;
        attackPower = thisCard[0].AttackPower;
        health = thisCard[0].Health;
        coolDown = thisCard[0].CoolDown;

        thisSprite = thisCard[0].ThisImage;
        thisEffectSprite = thisCard[0].EffectImage;

        nameText.text = "" +cardName;
        attackText.text = "" + attackPower.ToString ();
        healthText.text = "" + health.ToString ();
        cooldownText.text = "" +  coolDown.ToString ();

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

        activated = (TurnEnum.CurrentTurn >= (playedOnTurn + (coolDown * 2)));

        if (onBattleField) {
            if (activated) {
                if (Selected) {
                    Border.color = new Color(.12f, .96f, .16f);
                } else {
                    Border.color = new Color(.48f, .48f, .48f);
                }
            } else {
                Border.color = new Color(.92f, .08f, .08f);
            }
        } else {
            Border.color = new Color(.16f, .16f, .16f);
        }      
    }

    public static void DeselectAllCards()
    {
        var allCards = GameObject.FindObjectsOfType(typeof(ThisCard));
        foreach (var card in allCards)
        {
            (card as ThisCard).Selected = false;
        }
    }


}
