
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck= new List<Card>();
  static   public List<Card> staticDeck = new List<Card>();

    public int x;

   static  public int deckSize;

    public GameObject Hand;
    public GameObject CardToHand;
    public List<Card> container = new List<Card>();


    void Start()
    {

        /*NumbersOfCardInDeck4.SetActive(true);
        NumbersOfCardInDeck3.SetActive(true);
        NumbersOfCardInDeck2.SetActive(true);
        NumbersOfCardInDeck1.SetActive(true);*/
        x = 0;
        deckSize = 30;
        /*   for (int i =0; i < deckSize ; i++)
           {
               x = Random.Range(1, 20);
               deck[i] = CardDataBase.cardList[x];  

           }*/

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
        deck[29] = CardDataBase.cardList[19];
        publicShuffleDeck();
        StartCoroutine(StartGame(5));
        
    }

  public void   publicShuffleDeck()
    {
        for (int i = 0; i < deckSize ; i++)
        {
            container[0] = deck[i];
            int index = Random.Range(i, deckSize );
            deck[i] = deck[index];
            deck[index] = container[0];
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        staticDeck = deck;
        if (TurnEnum .StartTurn == true)
        {
            StartCoroutine(StartGame(1));
            TurnEnum.StartTurn =false;
        }

    }
    IEnumerator StartGame(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(CardToHand,transform.position, transform.rotation);
         

        }
    }

}
