using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameView : BaseView
    {
        [SerializeField] private TextMeshProUGUI pointsText;
        
        [SerializeField] private KnifeElement knifeElementPrefab;
        
        [SerializeField] private RectTransform knifeElementContent;


        private int knifeToDelete;

        private List<KnifeElement> spawnedElements = new List<KnifeElement>();
        
        
        public void UpdatePoints(int points)
        {
            pointsText.text = points.ToString();
        }

        public void SpawnAmmo(int ammo)
        {
            DespawnKnives();
            for (int i = 0; i < ammo; i++)
            {
                var newKnife = Instantiate(knifeElementPrefab, knifeElementContent);
                spawnedElements.Add(newKnife);
                newKnife.MarkAsUnlocked();
            }

            knifeToDelete = -1;
        }

        private void DespawnKnives()
        {
            for (int i = spawnedElements.Count -1; i >= 0; i--)
            {
                Destroy(spawnedElements[i].gameObject);
            }
            spawnedElements.Clear();
        }

        public void DecreaseAmmo()
        {
            knifeToDelete++;
            spawnedElements[knifeToDelete].MarkAsLocked();
        }
        
    }
    
}

