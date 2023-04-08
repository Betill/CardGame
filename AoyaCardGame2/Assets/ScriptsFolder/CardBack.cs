using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    public GameObject cardBack;

    public void ShowBack()
    {
        cardBack.SetActive(true);
    }

    public void ShowFront()
    {
        cardBack.SetActive(false);
    }
}
