using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectDescriptionText : MonoBehaviour
{
    public static string description;
    public static bool show;

    public Text text;

    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    void Update()
    {
        transform.position = Input.mousePosition;

        text.enabled = show;
        if (show)
            text.text = description;
    }
}
