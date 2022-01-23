using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class Knife : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D knifeRigidbody2D;
        [SerializeField] private float speed;
        public Rigidbody2D Rigidbody2D => knifeRigidbody2D;
        public void ThrowKnife()
        {
            knifeRigidbody2D.AddForce(Vector2.up * (speed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
        
    }
}
