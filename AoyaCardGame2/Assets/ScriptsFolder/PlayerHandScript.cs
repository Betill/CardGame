using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandScript : MonoBehaviour
{
  

    public GameObject Hand;
    public GameObject It;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("HandGO");
        It.transform.SetParent(Hand.transform);
        It.transform.localScale = Vector3.one;
    }
}
