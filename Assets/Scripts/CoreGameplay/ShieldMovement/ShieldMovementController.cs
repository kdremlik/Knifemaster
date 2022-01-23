using System.Collections;
using System.Collections.Generic;
using Generation;
using UnityEngine;
using UnityEngine.Events;

namespace CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyAcitveShield;

        public void InitializeShield(BaseShield newShield, UnityAction OnShieldCallback, UnityAction OnWinCallback)
        {
            if (currentlyAcitveShield != null)
                currentlyAcitveShield.Dispose();
            
            currentlyAcitveShield = newShield;
            currentlyAcitveShield.Initialize(OnShieldCallback,OnWinCallback);
            
            
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
