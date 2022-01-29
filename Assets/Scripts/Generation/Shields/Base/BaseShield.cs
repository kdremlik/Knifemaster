using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        private UnityAction onShlieldHit;
        private UnityAction onWin;
        
        [SerializeField]private int knivesToWin;
        
        public int KnivesToWin => knivesToWin;
        
        [SerializeField] protected ShieldMovementStep[] movementScheme;
        [SerializeField]private List<Knife> knivesInShield = new List<Knife>();

        
        public abstract void Rotate();
        public virtual void Initialize(UnityAction OnShieldCallback, UnityAction OnWinCallback)
        {
            onShlieldHit = OnShieldCallback;
            onWin = OnWinCallback;
        }
        
        public virtual void Dispose()
        {
            for (int i = knivesInShield.Count - 1; i >= 0; i--)
            {
                var knife = knivesInShield[i];
                Destroy(knife.gameObject);
                knivesInShield.Remove(knife);
            }
            knivesInShield.Clear();
            onShlieldHit = null;
            onWin = null;

            Destroy(this.gameObject);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var knife = other.GetComponentInParent<Knife>();
            knife.Rigidbody2D.velocity = Vector2.zero;
            knivesInShield.Add(knife);
            knife.Rigidbody2D.isKinematic = true;
            knife.transform.position = new Vector3(0, 0.35f, 0);
            knife.transform.SetParent(this.transform);
            
            
            onShlieldHit.Invoke();
            if (knivesInShield.Count == knivesToWin)
            {
                onWin.Invoke();
            }
            
        }
    }
}
