using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class SimpleShield : BaseShield
    {
        private float currentNormalizedTime;
        private float duration;
        private float startTime;
        private int currentStep;
        private Vector3 startAngle;
        private Vector3 endAngle;

        public override void Initialize()
        {
            currentStep = 0;
            var currentStepData = movementScheme[currentStep];
            startTime = Time.time;
            duration = currentStepData.time;
            currentNormalizedTime = 0f;
            startAngle = transform.rotation.eulerAngles;
            endAngle = startAngle + Vector3.forward * currentStepData.angle;

        }
        public override void Rotate()
        {
            // Debug.Log("ROTATE SHIELD" + this.gameObject.name);
            // transform.Rotate(Vector3.forward, 0.1f);
            currentNormalizedTime = (Time.time - startTime) / duration;
            if (currentNormalizedTime >= 1f)
            {
                currentStep++;
                if (currentStep == movementScheme.Length)
                    currentStep = 0;

                var currentStepData = movementScheme[currentStep];
                
                
                startTime = Time.time;
                duration = currentStepData.time;
                currentNormalizedTime = 0f;
                startAngle = transform.rotation.eulerAngles;
                endAngle = startAngle + Vector3.forward * currentStepData.angle;
            }

            var finalAngle = Vector3.Lerp(startAngle, endAngle, currentNormalizedTime);
            
            transform.rotation = Quaternion.Euler(finalAngle);
        }

    }
}
