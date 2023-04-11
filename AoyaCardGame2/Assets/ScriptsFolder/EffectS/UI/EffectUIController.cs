using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectUIController : MonoBehaviour
{
    public Button button;
    private ThisCard card;

    private void Start()
    {
        card = GetComponent<ThisCard>();
        card.OnCardSelected += ShowEffectButton;
        card.OnCardDeselected += HideEffectButton;        
    }

    private void ShowEffectButton()
    {
        Debug.Log("Showed");
        button.gameObject.SetActive(true);
    }

    private void HideEffectButton()
    {
        button.gameObject.SetActive(false);
    }
}
