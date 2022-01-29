using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class GameView : BaseView
    {
        [SerializeField] private TextMeshProUGUI pointsText;


        public void UpdatePoints(int points)
        {
            pointsText.text = points.ToString();
        }
    }
}

