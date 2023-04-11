using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
    public int coolDown;
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
    public GraveyardController Graveyard;
  

    public void OnPointerClick(PointerEventData eventData)
    {
        //DeselectAllCards();
        //TODO: Deselect all cards
        SelectCard();
    }

    private void SelectCard()
    {
        if (IsPlayerCard)
            OnCardSelected?.Invoke();
    }

    private void DeselectCard()
    {
        //Do color change
        if (IsPlayerCard)
            OnCardDeselected?.Invoke();
    }
   
    void Start()
    {
        cardBack = GetComponent<CardBack>();
        Enemy = GameObject.Find("EnemyGO(Clone)");
        Graveyard = GameObject.Find("GravePlayer")?.GetComponent<GraveyardController>();

        activated = false;
        InBattleSpace = false;

        thisSprite = thisCard.ThisImage;
        thisEffectSprite = thisCard.EffectImage;
        health = thisCard.Health;
        coolDown = thisCard.CoolDown;

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
        activated = coolDown <= 0; // (TurnsController.instance.TurnsCount >= (playedOnTurn + (thisCard.CoolDown * 2)));
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
            Border.color = new Color(.92f, .32f, .24f);
            return;
        }

        // Green for selected cards.
        if (Selected) {
            Border.color = new Color(.08f, .92f, .16f);
            return;
        }        

        // And red as a default, clickable state.
        Border.color = new Color(.92f, .92f, .92f);
    }

    public void Play(int cardIdr)
    {
        // how does that work - i would have used Drag/Drop
    }

    public void UpdateCooldown(int amount)
    {
        coolDown = Math.Max(0, coolDown + amount);
        cooldownText.text = coolDown.ToString();
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

    public void Attack(PlayerScript target)
    {
        AttackedThisTurn = true;
        target.UpdateHP(-thisCard.AttackPower);        
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
            Graveyard.AddCardToGraveyard(thisCard, IsPlayerCard);
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
            if (CanAttack(card)) {
                card.Attack(this);
            }
        }
    }

    public static bool CanAttack(ThisCard card)
    {
        return  card.IsPlayerCard &&
                card.onBattleField &&
                card.activated &&
                !card.AttackedThisTurn;
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
