using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KnifeElement : MonoBehaviour
{
    [SerializeField] private Image image;



    public void MarkAsLocked()
    {
        image.color = Color.black;
    }

    public void MarkAsUnlocked()
    {
        image.color = Color.white;
    }
    
    
}


