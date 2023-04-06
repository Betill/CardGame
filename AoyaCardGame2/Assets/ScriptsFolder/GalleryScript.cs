using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GalleryScript : MonoBehaviour
{
    public Button NextButton;
    public Button LastButton;
    public int ImageIndex;
    public Sprite[] sprites;
    public Sprite MySprite;
    private void Update()
    {

        MySprite = sprites[ImageIndex];

        if (ImageIndex <=0)
        {
            ImageIndex = 0;
            LastButton.gameObject.SetActive(false);
        }
        else
        {
            LastButton.gameObject.SetActive(true);
        }
        if (ImageIndex >= sprites.Length -1)
        {
            ImageIndex = sprites.Length - 1;
            NextButton.gameObject.SetActive(false);
        }
        else
        {
            NextButton.gameObject.SetActive(true);
        }
    }

    public void ClickNextButton()
    {
        ImageIndex = ImageIndex += 1;

    }
    public void ClickLastButton()
    {
        ImageIndex = ImageIndex -= 1;
    }
}
