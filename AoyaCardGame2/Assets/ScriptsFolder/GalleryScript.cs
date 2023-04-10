using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GalleryScript : MonoBehaviour
{
    public Button NextButton;
    public Button LastButton;
    public int ImageIndex =0;
    public RawImage rawImage;
    public Texture[] tex;
    private void Update()
    {
        rawImage.texture = tex[ImageIndex]; 

        if (ImageIndex <=0)
        {
            ImageIndex = 0;
            LastButton.gameObject.SetActive(false);
        }
        else
        {
            LastButton.gameObject.SetActive(true);
        }
        if (ImageIndex >= tex .Length -1)
        {
            ImageIndex = tex.Length - 1;
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
