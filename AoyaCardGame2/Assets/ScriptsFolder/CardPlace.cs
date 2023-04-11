using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class CardPlace : MonoBehaviour, IDropHandler, IPointerEnterHandler ,IPointerExitHandler     
{
    public ThisCard[] cardsOnBF => panel.transform.GetComponentsInChildren<ThisCard>();
    public GameObject panel;

    public bool isEnemy;

    private void Start()
    {
        //BattleFiledManager.Instance.TriggerEventListener("CardPlaced");
    }

    // public GameObject[] CardsOnField;
    public void OnDrop(PointerEventData eventData)
    {
        if (isEnemy)
            return;

        DragCard drag = eventData.pointerDrag.GetComponent<DragCard>();
        if (cardsOnBF.Length < 4) {
            drag.parentToReturnTo = transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isEnemy)
            return;

        if (eventData .pointerDrag == null) {
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
        if (isEnemy)
            return;

        if (eventData.pointerDrag == null) {
            return;
        }

        DragCard dragcard2 = eventData.pointerDrag.GetComponent<DragCard>();
        if(dragcard2 != null && dragcard2.placeholderParent == this.transform )
        {
            dragcard2.placeholderParent = dragcard2.parentToReturnTo;
            
        }
    }
}
