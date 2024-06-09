using System.Collections.Generic;
using DG.Tweening;
using GameLogic;
using Infrastructure;
using TMPro;
using Tools.Timer;
using UnityEngine;

namespace UI
{
    public class GameplayUI : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private List<ColorSelect> _colors;
  
        private int _lastSelectedIndex;
        
        public void Init()
        {
            Show();
        }

        private void Show(bool isFirst = true)
        {
            if (_colors.Count == 0) return;
            _canvasGroup.DOFade(1, 0.5f);
            if (!isFirst)
                SelectLast();
            else
                SelectFirst();
        }
        
        public void Hide()
        {
            int lastIndex = 0;
            _canvasGroup.DOFade(0, 0.5f);
            foreach (var color in _colors)
            {
                lastIndex++;
                if(color.IsSelected) break;
            }
            _lastSelectedIndex = lastIndex;
        }

        private void SelectFirst()
        {
            _colors[0].SelectColor();
        }

        private void SelectLast()
        {
            _colors[_lastSelectedIndex].SelectColor();
        }
    }
}