using System.Collections;
using System.Collections.Generic;
using Generation;
using UnityEngine;

namespace CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyAcitveShield;

        public void InitializeShield(BaseShield newShield)
        {
            currentlyAcitveShield = newShield;
            currentlyAcitveShield.Initialize();
        }

        public void UpdateController()
        {
            if (currentlyAcitveShield != null)
            {
                currentlyAcitveShield.Rotate();
            }
        }
    }
}
