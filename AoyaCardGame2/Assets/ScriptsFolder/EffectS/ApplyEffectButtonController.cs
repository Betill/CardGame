using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyEffectButtonController : MonoBehaviour
{
    private ThisCard thisCard;
    private Button button;
    private EffectController effectController;
    private void Awake()
    {
        thisCard = GetComponentInParent<ThisCard>();
        button = GetComponent<Button>();
        effectController = GameObject.FindObjectOfType<EffectController>();

        button.onClick.AddListener(ApplyEffects);
    }

    private void ApplyEffects()
    {
        effectController.applyCardEffects(thisCard.thisCard);
    }

}