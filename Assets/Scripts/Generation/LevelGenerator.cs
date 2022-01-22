using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform shieldPos;
        
        [SerializeField]
        private Transform knifePos;

        [SerializeField] private BaseShield shieldPrefab;

        [SerializeField] private Transform shieldRoot;
        public void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, shieldPos.position, shieldPos.rotation);
            shieldObj.transform.SetParent(shieldRoot);
        }
        
    }
}
