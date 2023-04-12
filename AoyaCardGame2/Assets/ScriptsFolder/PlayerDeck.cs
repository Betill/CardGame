
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerDeck : MonoBehaviour
{
    public static List<Card> deck= new List<Card>();
    static public List<Card> staticDeck = new List<Card>();

    static public int deckSize;
    public bool IsPlayer;
    public GameObject Hand;
    public GameObject CardToHand;
    //public List<Card> container = new List<Card>();
    public PlayerScript player;
    public bool HasCard;

    public List<ThisCard> hand = new List<ThisCard>();

    void Awake()
    {

        /*NumbersOfCardInDeck4.SetActive(true);
        NumbersOfCardInDeck3.SetActive(true);
        NumbersOfCardInDeck2.SetActive(true);
        NumbersOfCardInDeck1.SetActive(true);*/
        loadDeckData();
        publicShuffleDeck();
        HasCard = true;
        //DrawCard(5);
    }

    private void loadDeckData()
    {
       
        deck.Add(CardDataBase.cardList[0]);
        deck.Add(CardDataBase.cardList[0]);
        deck.Add(CardDataBase.cardList[1]);
        deck.Add(CardDataBase.cardList[1]);
        deck.Add(CardDataBase.cardList[2]);
        deck.Add(CardDataBase.cardList[2]);
        deck.Add(CardDataBase.cardList[3]);
        deck.Add(CardDataBase.cardList[3]);
        deck.Add(CardDataBase.cardList[3]);
        deck.Add(CardDataBase.cardList[4]);
        deck.Add(CardDataBase.cardList[4]);
        deck.Add(CardDataBase.cardList[5]);
       deck.Add(CardDataBase.cardList[5]);
        deck.Add(CardDataBase.cardList[6]);
        deck.Add(CardDataBase.cardList[6]);
        deck.Add(CardDataBase.cardList[7]);
        deck.Add(CardDataBase.cardList[8]);
        deck.Add(CardDataBase.cardList[9]);
        deck.Add(CardDataBase.cardList[7]);
        deck.Add(CardDataBase.cardList[8]);
        deck.Add(CardDataBase.cardList[9]);
        deck.Add(CardDataBase.cardList[10]);
        deck.Add(CardDataBase.cardList[11]);
        deck.Add(CardDataBase.cardList[12]);
        deck.Add(CardDataBase.cardList[13]);
        deck.Add(CardDataBase.cardList[14]);
        deck.Add(CardDataBase.cardList[15]);
        deck.Add(CardDataBase.cardList[15]);
        deck.Add(CardDataBase.cardList[16]);
        deck.Add(CardDataBase.cardList[17]);
        deck.Add(CardDataBase.cardList[18]);
        deck.Add(CardDataBase.cardList[19]); 


        deckSize = deck.Count;
    }

    public void publicShuffleDeck()
    {
        for (int i = 0; i < deckSize ; i++)
        {
            Card auxCard = deck[i];
            int index = Random.Range(i, deckSize);
            deck[i] = deck[index];
            deck[index] = auxCard;
        }
    }

    public void DrawCard(int amount)
    {
        StartCoroutine(StartRound(amount));
    }

    private Card RemoveCardFromDeck()
    {
        if(deck == null || deck.Count == 0)
        {
         PlayerScript NoDeckPlayer=   player.GetComponent<PlayerScript>();
            NoDeckPlayer.CurrentHP -= 1;
            HasCard = false;
            Debug.Log("You do not have cards anymore！");
            return null;

        }

        Card card = deck[0];
        deck.RemoveAt(0);

        return card;
    }

    IEnumerator StartRound(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Card card = RemoveCardFromDeck();

            if (card == null) yield return null;

            yield return new WaitForSeconds(0.5f);

            AddCardToHand(card);
            
        }
    }

    public void AddCardToHand(Card card)
    {
        if (Hand.transform.childCount >8)
        {
            return;
        }
        if (HasCard )
        {
            GameObject obj = Instantiate(CardToHand, transform.position, transform.rotation);
            obj.GetComponent<CardInHandZone>().Play(Hand.transform);
            obj.GetComponent<ThisCard>().IsPlayerCard = IsPlayer;
            obj.GetComponent<ThisCard>().Hand = Hand;
            obj.GetComponent<ThisCard>().thisCard = card;
            hand.Add(obj.GetComponent<ThisCard>());

            if (!IsPlayer)
            {
                Destroy(obj.GetComponent<ApplyEffectButtonController>());
                Destroy(obj.GetComponent<DragCard>());
            }
        }
       
    }

}
