using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShuffleHandCard : MonoBehaviour
{
    // public GameObject[] HandCards;
    // public GameObject parentOfHandCards;
    // private int LengthOfHand;

    public GameObject[] handcards;
    public Transform parentHand;
    static int indexofhandcard;
    private void Start()
    {
        parentHand= GameObject.Find("Hand").transform;
    }
    public void HandShuffled()
    {

        try
        {
               handcards = GameObject.FindGameObjectsWithTag("InHand");
        handcards[indexofhandcard ].transform.SetAsLastSibling();
        indexofhandcard++;
            if (handcards.Length == indexofhandcard )
            {
                indexofhandcard = 0;
            };
        }
        catch (System.Exception)
        {
            indexofhandcard = 0;
            throw;
        }
    
    }


}
