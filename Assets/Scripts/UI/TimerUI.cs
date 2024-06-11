using DG.Tweening;
using GameLogic;
using Infrastructure;
using TMPro;
using Tools.Timer;
using UnityEngine;
using Zenject;

namespace UI
{
    public class TimerUI : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private CanvasGroup _canvasGroup;

        private float _time = 15f;
        private EventsService _eventsService;

        [Inject]
        public void Construct(EventsService eventsService)
        {
            _eventsService = eventsService;
        }
        
        public void Init()
        {
            _canvasGroup.alpha = 0;
        }

        public void StartTimer()
        {
            _canvasGroup.DOFade(1, 0.5f);
            var timer = new Timer(_time, _timerText, this);
            timer.TimerEnded += EndTime;
            timer.TimerEnded += _eventsService.OnTimeEnded;
            timer.Start();
        }

        private void EndTime()
        {
            _timerText.text = string.Empty;
            _canvasGroup.DOFade(0, 1f);
        }
        
    }
}