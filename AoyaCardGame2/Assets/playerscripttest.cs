using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerscripttest : MonoBehaviour
{
    public bool status = true;
    // Start is called before the first frame update
    void Start()
    {
    }

   /* private UnityAction SoHeDead()
    {
        throw new NotImplementedException();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.V ))
        {
            deaduwu();
        }
        
    }

    private void deaduwu()
    {
        status = false;
        Debug.Log("He is dead");

        BattleFiledManager.Instance.TriggerEventListener("He dead.");
    }
}
