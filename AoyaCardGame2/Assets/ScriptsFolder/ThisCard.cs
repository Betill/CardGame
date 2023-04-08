using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThisCard : MonoBehaviour, IPointerClickHandler 
{
    public int id;
    public Card thisCard;

    public Sprite thisSprite;
    public Image thatImage;
    public Image Border;

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

    private CardBack cardBack;

    public UnityAction OnCardSelected;
    public UnityAction OnCardDeselected;

    public void OnPointerClick(PointerEventData eventData)
    {
        //DeselectAllCards();
        //TODO: Deselect all cards
        SelectCard();

    }

    private void SelectCard()
    {
        Debug.Log("Selected");
        /*if (!onBattleField)
        {
            Border.color = new Color(.16f, .16f, .16f);
            return;
        }

        if (!activated)
        {
            Border.color = new Color(.92f, .08f, .08f);
            return;
        }

        if (!Selected)
        {
            Border.color = new Color(.48f, .48f, .48f);
            return;
        }*/

        Border.color = new Color(.12f, .96f, .16f);
        OnCardSelected?.Invoke();
    }

    private void DeselectCard()
    {
        //Do color change
        OnCardDeselected?.Invoke();
    }

   
    void Start()
    {
        thisCard = PlayerDeck.deck[id];
        cardBack = GetComponent<CardBack>();
        NumbersOfCardsInDeck = PlayerDeck.deckSize;
        Enemy = GameObject.Find("EnemyGO(Clone)");

        activated = false;
        InBattleSpace = false;
        thisSprite = thisCard.ThisImage;
        thisEffectSprite = thisCard.EffectImage;

        nameText.text = "" + thisCard.CardName;
        attackText.text = "" + thisCard.AttackPower.ToString();
        healthText.text = "" + thisCard.Health.ToString();
        cooldownText.text = "" + thisCard.CoolDown.ToString();

        if (this.transform.parent == Hand.transform)
        {
            if (IsPlayerCard)
            {
                IsCardBack = false;
                cardBack.ShowFront();
            }
            else
            {
                IsCardBack = true;
                cardBack.ShowBack();
            }
        }

        BattlePanel = GameObject.Find("Panel");
        if (this.transform.parent == BattlePanel.transform)
        {
            gameObject.GetComponent<DragCard>().enabled = false;
        }

        thatImage.sprite = thisSprite;
        thatEffectImage.sprite = thisEffectSprite;

        //  IsCardBackStatic = IsCardBack;
        // CardBackScript.UpdateCard(IsCardBack);

        if (this.tag == "Clone")
        {
            thisCard = PlayerDeck.deck[NumbersOfCardsInDeck - 1];

            NumbersOfCardsInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            IsCardBack = false;
            this.tag = "InHand";
        }

        activated = (TurnEnum.CurrentTurn >= (playedOnTurn + (thisCard.CoolDown * 2)));

    }

    public void Play(int cardIdr)
    {
        
    }

    //public static void DeselectAllCards()
    //{
    //    var allCards = GameObject.FindObjectsOfType(typeof(ThisCard));
    //    foreach (var card in allCards)
    //    {
    //        (card as ThisCard).Selected = false;
    //    }
    //}


}
