using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextPanel : MonoBehaviour
{

    public Text textofplayerstatus;
    void Start()
    {
        textofplayerstatus = GetComponent<Text>();
        BattleFiledManager.Instance.AddEventListener("He dead.", ShowMassage);
    }

    public void ShowMassage()
    {
        Debug.Log("UWU player dead");
        textofplayerstatus.text = "he dead uwu";

    }

}
