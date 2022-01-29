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

        [SerializeField] private List<DotElement> stageElements = new List<DotElement>();


        [SerializeField]
        private TextMeshProUGUI stageText;
        
        
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

        public void UpdateStage(int currentStage)
        {
            if (currentStage == 0)
            {
                stageText.color = Color.red;
                stageText.text = "BOSS FIGHT";
                for (int i = 0; i < stageElements.Count; ++i)
                {
                    stageElements[i].gameObject.SetActive(false);
                }
                stageElements[stageElements.Count - 1].gameObject.SetActive(true);
            }
            else
            {
                if (currentStage == 1)
                {
                    for (int i = 0; i < stageElements.Count; ++i)
                    {
                        stageElements[i].gameObject.SetActive(true);
                        stageElements[i].MarkAsLocked();
                    }
                    stageElements[stageElements.Count - 1].gameObject.SetActive(false);
                }
                
                stageElements[currentStage-1].MarkAsUnlocked();
                stageText.color = Color.white;
                stageText.text = "STAGE" + currentStage;
            }
            
            
            
        }
        
    }
    
}

