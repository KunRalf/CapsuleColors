using System;
using System.Collections;
using GameLogic;
using Infrastructure;
using TMPro;
using UnityEngine;
using Zenject;

namespace Tools.Timer
{
    public class Timer
    {
        public event Action TimerStarted;
        public event Action<float> TimerProgress;
        public event Action TimerEnded;
        
        private float _time;
        private readonly TextMeshProUGUI _text;
        private readonly ICoroutineRunner _coroutineRunner;
        private EventsService _events;

        [Inject]
        public void Construct(EventsService eventsService)
        {
            _events = eventsService;
        }
        
        public Timer(float time, TextMeshProUGUI text, ICoroutineRunner coroutineRunner)
        {
            _time = time;
            _text = text;
            _coroutineRunner = coroutineRunner;
        }

        public void Start()
        { 
            _coroutineRunner.StartCoroutine(StartTimer());
        }
        
        private IEnumerator StartTimer()
        {
            TimerStarted?.Invoke();
            while (_time > 0)
            {
                _time -= Time.deltaTime;
                _text.text = _time.ToString("0.0");
                if (_time <= 0)
                {
                    _text.text = "0";
                }
                TimerProgress?.Invoke(_time);
                yield return null;
            }
            TimerEnded?.Invoke();
        }
    
    }
}