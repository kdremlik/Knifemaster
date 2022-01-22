using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generation
{
    public class LevelGenerator : MonoBehaviour
    {
        

        [Header("Shield")]
        [SerializeField] private Transform shieldPos;
        [SerializeField] private BaseShield shieldPrefab;
        [SerializeField] private Transform shieldRoot;

        [Header("Knife")]
        [SerializeField] private Transform knifePos;
        [SerializeField] private BaseKnife knifePrefab;
        [SerializeField] private Transform knifeRoot;
        public void SpawnShield()
        {
            var shieldObj = Instantiate(shieldPrefab, shieldPos.position, shieldPos.rotation);
            shieldObj.transform.SetParent(shieldRoot);
        }

        public void SpawnKnife()
        {
            var knifeObj = Instantiate(knifePrefab, knifePos.position, knifePos.rotation);
            knifeObj.transform.SetParent(knifeRoot);
        }
    }
}