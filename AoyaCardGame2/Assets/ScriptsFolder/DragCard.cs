using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragCard : MonoBehaviour, IBeginDragHandler ,IDragHandler,IEndDragHandler 
{
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject originalPlace = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
       // Debug.Log("You clicked card");
        originalPlace = new GameObject();
        originalPlace.transform.SetParent(this.transform.parent);
        LayoutElement CardLayOut = originalPlace.AddComponent<LayoutElement>();
        CardLayOut.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        CardLayOut.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;

        CardLayOut.flexibleHeight = 0;
        CardLayOut.preferredWidth = 0;
        //
        originalPlace.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeholderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

     // GetComponent<CanvasGroup>().blocksRaycasts = false;

      //  this.transform.SetParent ( this.transform.parent.parent );

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
      // Debug.Log("You drag card");
        this.transform.position = eventData.position;

        if (originalPlace.transform.parent != placeholderParent)
        {
            originalPlace.transform.SetParent(placeholderParent);
        }

        int SiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x )
            {
                SiblingIndex = i;
                if(originalPlace.transform.GetSiblingIndex ()<SiblingIndex )
                {
                    SiblingIndex--;
                    break;
                }
            }
        }
        originalPlace.transform.SetSiblingIndex(SiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
      //  Debug.Log("You end drag card");
       
        this.transform.SetParent(parentToReturnTo );
        this.transform.SetSiblingIndex(originalPlace.transform.GetSiblingIndex());
       GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(originalPlace);
    }

  
}
