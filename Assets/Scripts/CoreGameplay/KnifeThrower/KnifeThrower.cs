using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class KnifeThrower
    {
        private Knife knife;

        public void SetKnife(Knife newKnife)
        {
            this.knife = newKnife;
        }

        public void Throw()
        {
            if (knife != null)
            {
                knife.ThrowKnife();
                knife = null;
            }
            
        }
    }
}
