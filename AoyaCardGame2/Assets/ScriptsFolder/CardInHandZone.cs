using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CardInHandZone : MonoBehaviour
{
    public GameObject HandZone;
    public GameObject It;

    // Start is called before the first frame update
    void Start()
    {
        HandZone = GameObject.Find("Hand");// Finds a GameObject on scene by name and returns it.

        It.transform.SetParent(HandZone.transform);
        It.transform.localScale = Vector3.one;
        //local scale = The scale of the transform relative to the GameObjects parent.
        It.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        It.transform.eulerAngles = new Vector3(25, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
