using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class KnifeElement : MonoBehaviour
{
    [SerializeField] private Image image;
    private Color dimmedWhite = new Color(0.82f, 0.82f, 0.82f); 


    public void MarkAsLocked()
    {
        image.DOColor(Color.black, 0.2f);
        
    }

    public void MarkAsUnlocked()
    {
        image.color = dimmedWhite;
    }
    
    
}


