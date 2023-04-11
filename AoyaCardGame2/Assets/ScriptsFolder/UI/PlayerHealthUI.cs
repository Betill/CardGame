using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Text healthText;

    private void Awake()
    {
        //PlayerScript.OnHPUpdated += UpdateHealthText;
    }

    private void UpdateHealthText(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}
