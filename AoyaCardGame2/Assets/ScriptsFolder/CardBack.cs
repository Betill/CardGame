using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    public ThisCard thiscard; // new
    public GameObject card; // new
    public GameObject cardBack;


    // Start is called before the first frame update
    void Start()
    {
        thiscard = card.GetComponent<ThisCard>();
    }

    // Update is called once per frame
  void Update()
    {
        if (thiscard.IsCardBack  ) // was static
        {
            cardBack.SetActive(true);
        }
        else
        {
            cardBack.SetActive(false);
        }
       
    }
   /* public void UpdateCard(bool updown)
    {
        cardBack.SetActive(updown);
    }*/
}
