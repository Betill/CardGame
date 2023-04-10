using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThisCard : MonoBehaviour, IPointerClickHandler, IDropHandler
{
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

    public int health;
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
    public bool AttackedThisTurn;

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
        OnCardSelected?.Invoke();
    }

    private void DeselectCard()
    {
        //Do color change
        OnCardDeselected?.Invoke();
    }
   
    void Start()
    {
        cardBack = GetComponent<CardBack>();
        Enemy = GameObject.Find("EnemyGO(Clone)");

        activated = false;
        InBattleSpace = false;

        thisSprite = thisCard.ThisImage;
        thisEffectSprite = thisCard.EffectImage;
        health = thisCard.Health;

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
              
        thatImage.sprite = thisSprite;
        thatEffectImage.sprite = thisEffectSprite;


        if (this.tag == "Clone")
        {
            //thisCard = PlayerDeck.deck[NumbersOfCardsInDeck - 1];

            //PlayerDeck.deckSize -= 1;
            IsCardBack = false;
            this.tag = "InHand";
        }

    }

    private void FixedUpdate()
    {
        if (transform.parent.tag == "Battlefield") {
            onBattleField = true;
            cardBack.ShowFront();
        }
        activated = (TurnEnum.CurrentTurn >= (playedOnTurn + (thisCard.CoolDown * 2)));
        UpdateBorder();
    }

    private void UpdateBorder()
    {
        // Dark gray for hand cards.
        if (!onBattleField) {
            Border.color = new Color(.16f, .16f, .16f);
            return;
        }

        // Light gray for inactive or already used cards.
        if (!activated || AttackedThisTurn) {
            Border.color = new Color(.48f, .48f, .48f);
            return;
        }

        // Green for selected cards.
        if (Selected) {
            Border.color = new Color(.08f, .92f, .08f);
            return;
        }

        // And red as a default, clickable state.
        Border.color = new Color(.92f, .16f, .16f);
    }

    public void Play(int cardIdr)
    {
        // how does that work - i would have used Drag/Drop
    }

    public void UpdateCooldown(int amount)
    {
        thisCard.CoolDown = Mathf.Clamp(thisCard.CoolDown + amount, 0, 100);
    }

    public void UpdateHealth()
    {

    }

    public void Attack(ThisCard target)
    {
        Debug.Log(nameText.text + " attacks " + target.nameText.text + "!");
        AttackedThisTurn = true;
        int enemyDamage = target.thisCard.AttackPower;
        target.Hit(thisCard.AttackPower);        
        Hit(enemyDamage);
    }

    public void Hit(int amount)
    {
        health -= amount;
        if (health <= 0) {
            // remove the placeholder card from battlefield in case this card dies.
            DragCard drag = GetComponent<DragCard>();
            if (drag != null && drag.originalPlace != null) {
                Destroy(drag.originalPlace);
            }
            // also kill the card itself
            Destroy(gameObject);
        } else {
            // if we did not die, just update health text
            healthText.text = health.ToString();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        // drag and drop attack handling        
        if (!onBattleField)
            return;

        // only allow during player turn
        if (TurnsController.instance.CurrentTurn != 0)
            return;

        ThisCard card = DragCard.currentCard;
        if (card != null) {
            // do all legality checks.
            if (
                    card.IsPlayerCard && 
                    card.onBattleField &&
                    card.activated &&
                    !card.AttackedThisTurn) {
                card.Attack(this);
            }
        }
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
