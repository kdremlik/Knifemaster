using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Points
{
    public class PointsController
    {
        private int currentPoints;
        
        public int CurrentPoints => currentPoints;

        public void InitSystem()
        {
            currentPoints = 0;
        }
        
        
        public void IncresePoints()
        {
            currentPoints++;
        }
    }
}
