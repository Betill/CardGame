using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{

    public string PlayerName;
    public int MaxHP;
    public int CurrentHP;
    public static UnityAction<int> OnHPUpdated;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHP(int amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP + amount, 0, MaxHP);
        OnHPUpdated?.Invoke(CurrentHP);
    }
}
