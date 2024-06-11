using GameLogic;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private ColorButtons colorButtons;
        [SerializeField] private TimerUI _timerUI;
        private EventsService _eventsService;

        [Inject]
        public void Construct(EventsService eventsService)
        {
            _eventsService = eventsService;
        }
        
        public void Init()
        {
            colorButtons.Init();
            _timerUI.Init();
            _eventsService.PlatformOnStation += StartTimer;
        }

        private void StartTimer(bool value, int id)
        {
            if(value)
               _timerUI.StartTimer();
        }
    }
}