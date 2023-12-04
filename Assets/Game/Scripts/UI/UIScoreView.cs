using UnityEngine;
using TMPro;
using System;

namespace ShootEmUp
{
    [Serializable]
    public class UIScoreView
    {
        [SerializeField] private TMP_Text _score;

        public void UpdateScore(string score) => _score.text = score;
    }
}