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
        if (GetComponentInParent<ThisCard>().EffectUsed)
            return;

        Debug.Log("Showed");
        button.gameObject.SetActive(true);
    }

    private void HideEffectButton()
    {
        if (GetComponentInParent<ThisCard>().EffectUsed)
            return;

        button.gameObject.SetActive(false);
    }
}
