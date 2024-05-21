using System;
using GameLogic;
using Tools.Toggle;
using UnityEditor.MPE;
using UnityEngine;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(ToggleCustom))]
    public class ColorSelect : MonoBehaviour
    {
        private ToggleCustom _toggleCustom;
        [SerializeField] private Color _color;
        private EventsService _eventsService;


        [Inject]
        public void Construct(EventsService eventsService)
        {
            _eventsService = eventsService;
        }
        
        private void Awake()
        {
            _toggleCustom = GetComponent <ToggleCustom>();
        }

        private void OnEnable()
        {
            _toggleCustom.OnValueChanged.AddListener(Select);
        }

        private void OnDisable()
        {
            _toggleCustom.OnValueChanged.RemoveListener(Select);
        }

        public void Select(bool value)
        {
            if (!value) return;
            _eventsService.OnChangedColor(_color);
            
        }
    }
}