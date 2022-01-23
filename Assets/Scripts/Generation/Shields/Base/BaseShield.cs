using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField] protected ShieldMovementStep[] movementScheme;
        
        [SerializeField]private List<Knife> knivesInShield = new List<Knife>();
        
        public abstract void Rotate();
        public abstract void Initialize();

        private void OnTriggerEnter2D(Collider2D other)
        {
            var knife = other.GetComponent<Knife>();
            knife.Rigidbody2D.velocity = Vector2.zero;
            knivesInShield.Add(knife);
            knife.transform.position = new Vector3(0, 0.35f, 0);
            knife.transform.SetParent(this.transform);
        }
    }
}
