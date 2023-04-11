using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour, IDropHandler
{
    public string PlayerName;
    public int MaxHP;
    public int CurrentHP;
    public static UnityAction<int> OnHPUpdated;
    public bool isPlayer;

    public Text healthText;

    void Start()
    {
        healthText.text = CurrentHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHP(int amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP + amount, 0, MaxHP);
        OnHPUpdated?.Invoke(CurrentHP);
        healthText.text = CurrentHP.ToString();
        if (CurrentHP <= 0) {
            if (isPlayer)
                Debug.Log("you lost!");
            else
                Debug.Log("you won!");
            SceneManager.LoadScene("StartMenu");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (isPlayer)
            return;

        // only allow during player turn
        if (TurnsController.instance.CurrentTurn != 0)
            return;

        ThisCard card = DragCard.currentCard;
        if (card != null) {
            if (ThisCard.CanAttack(card)) {
                card.Attack(this);
            }
        }
    }
}
