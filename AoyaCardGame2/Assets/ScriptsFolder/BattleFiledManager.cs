using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static System.Collections.Specialized.BitVector32;

public class BattleFiledManager
{

    private static BattleFiledManager instance; // singleton mode 
    public static BattleFiledManager Instance // getter and setter
    {  // observer pattern 
        get {
            if (instance == null)
            {
                instance = new BattleFiledManager();
            }
            return instance;
        }
    }


    // manages events on scene 
    // uses dictionary to maintenance events : add, delete, triggers, empty 

    Dictionary<string, UnityAction> DictionOfEvents = new Dictionary<string, UnityAction>();

    // adds an  event
    public void AddEventListener(string  eventname, UnityAction action) {

        if (DictionOfEvents.ContainsKey (eventname )) // if the events is already added to dictionary
        {
            DictionOfEvents[eventname] += action; // add events based on this already existing key (eventname)
        }
    else // if not, create a new key value paeir
        {
            DictionOfEvents.Add(eventname, action);

        }
    
    }
    // remove an events

    public void RemoveEventListener(string eventname, UnityAction action)
    {
        if (DictionOfEvents.ContainsKey(eventname)) // if there is a event
        {
            DictionOfEvents[eventname] -= action; // unregister this events
        }
        
    }

    // triggers  an event

    public void TriggerEventListener(string eventname)
    {
        // must decides if the event exists

        if (DictionOfEvents.ContainsKey(eventname)) // if there is a event
        {
            DictionOfEvents[eventname].Invoke();// do this event
        }
    }

    // empty  events
    public void CleanEventListener()
    {
        DictionOfEvents.Clear();
    }
}
