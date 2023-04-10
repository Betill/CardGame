using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class CardPlace : MonoBehaviour, IDropHandler, IPointerEnterHandler ,IPointerExitHandler     
{
    public ThisCard [] cardsOnBF;
    public GameObject panel;

    private void Start()
    {
        //BattleFiledManager.Instance.TriggerEventListener("CardPlaced");
    }

    // public GameObject[] CardsOnField;
    public void OnDrop(PointerEventData eventData)
    {
        //panel = GameObject.Find("Panel");
        cardsOnBF = panel.transform.GetComponentsInChildren<ThisCard>();
        int i =this.transform.childCount;
        DragCard drag = eventData.pointerDrag.GetComponent<DragCard>();
        if (drag != null&&i <5)
        {
            drag.parentToReturnTo = this.transform;
            foreach (ThisCard  item in cardsOnBF )
            {
                if (item.thisCard.CoolDown ==0)
                {
                    
                }
            }
            //Debug.Log("was dropped on battle filed");
        }

    }



    public void OnPointerEnter(PointerEventData eventData)
    {
       // Debug.Log("Card entered the cardplace");
        if (eventData .pointerDrag == null)
        {
            return;
        }

        DragCard dragcard = eventData.pointerDrag.GetComponent<DragCard>();
        if (dragcard != null)
        {
            dragcard.placeholderParent = this.transform;
        }
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      //  Debug.Log("Card exited the cardplace");
        if (eventData.pointerDrag ==null)
        {
            return;
        }
        DragCard dragcard2 = eventData.pointerDrag.GetComponent<DragCard>();
        if(dragcard2 != null && dragcard2.placeholderParent == this.transform )
        {
            dragcard2.placeholderParent = dragcard2.parentToReturnTo;
            
        }
    }
}
