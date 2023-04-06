using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CardInHandZone : MonoBehaviour
{
    public GameObject It;

    public void Play(Transform targetHand)
    {
        It.transform.SetParent(targetHand);
        It.transform.localScale = Vector3.one;
        //local scale = The scale of the transform relative to the GameObjects parent.
        It.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        It.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
