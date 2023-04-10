
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public static List<Card> deck= new List<Card>();
    static public List<Card> staticDeck = new List<Card>();

    static public int deckSize;

    public bool IsPlayer;
    public GameObject Hand;
    public GameObject CardToHand;
    //public List<Card> container = new List<Card>();

    public List<ThisCard> hand = new List<ThisCard>();

    void Awake()
    {

        /*NumbersOfCardInDeck4.SetActive(true);
        NumbersOfCardInDeck3.SetActive(true);
        NumbersOfCardInDeck2.SetActive(true);
        NumbersOfCardInDeck1.SetActive(true);*/
        loadDeckData();
        publicShuffleDeck();
        //DrawCard(5);
    }

    private void loadDeckData()
    {
        /*
deck[0] = CardDataBase.cardList[0];
deck[1] = CardDataBase.cardList[0];
deck[2] = CardDataBase.cardList[1];
deck[3] = CardDataBase.cardList[1];
deck[4] = CardDataBase.cardList[2];
deck[5] = CardDataBase.cardList[3];
deck[6] = CardDataBase.cardList[4];
deck[7] = CardDataBase.cardList[5];
deck[8] = CardDataBase.cardList[6];
deck[9] = CardDataBase.cardList[7];
deck[10] = CardDataBase.cardList[7];
deck[11] = CardDataBase.cardList[8];
deck[12] = CardDataBase.cardList[9];
deck[13] = CardDataBase.cardList[10];
deck[14] = CardDataBase.cardList[11];
deck[15] = CardDataBase.cardList[11];
deck[16] = CardDataBase.cardList[12];
deck[17] = CardDataBase.cardList[12];
deck[18] = CardDataBase.cardList[13];
deck[19] = CardDataBase.cardList[13];
deck[20] = CardDataBase.cardList[14];
deck[21] = CardDataBase.cardList[14];
deck[22] = CardDataBase.cardList[15];
deck[23] = CardDataBase.cardList[15];
deck[24] = CardDataBase.cardList[16];
deck[25] = CardDataBase.cardList[17];
deck[26] = CardDataBase.cardList[18];
deck[27] = CardDataBase.cardList[18];
deck[28] = CardDataBase.cardList[19];
deck[29] = CardDataBase.cardList[19];*/
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
        deck.Add(CardDataBase.cardList[5]);
        deck.Add(CardDataBase.cardList[6]);
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
        deck.Add(CardDataBase.cardList[15]);
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
            GameObject obj = Instantiate(CardToHand, transform.position, transform.rotation);
            obj.GetComponent<CardInHandZone>().Play(Hand.transform);
            obj.GetComponent<ThisCard>().IsPlayerCard = IsPlayer;
            obj.GetComponent<ThisCard>().Hand = Hand;
            obj.GetComponent<ThisCard>().thisCard = card;
            hand.Add(obj.GetComponent<ThisCard>());

            if (!IsPlayer) {
                Destroy(obj.GetComponent<DragCard>());
            }
        }
    }

}
