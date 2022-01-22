using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField] protected ShieldMovementStep[] movementScheme;
        public abstract void Rotate();
        public abstract void Initialize();

    }
}
