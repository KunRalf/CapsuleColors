using System;
using GameLogic;
using GameLogic.DataObjects.Objects;
using Tools.Toggle;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(ToggleCustom))]
    public class ColorSelect : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private ToggleCustom _toggleCustom;
        [SerializeField] private ColorPreset _colorPreset;
        private EventsService _eventsService;
        public bool IsSelected => _toggleCustom.IsOn;

        [Inject]
        public void Construct(EventsService eventsService)
        {
            _eventsService = eventsService;
        }
        
        public void SelectColor()
        {
            _toggleCustom.IsOn = true;
            _eventsService.OnChangedColor(_colorPreset);
        }
        
        private void Awake()
        {
            _toggleCustom = GetComponent <ToggleCustom>();
            if (_image != null && _colorPreset != null)
                _image.color = _colorPreset.Color;
        }

        private void OnEnable()
        {
            _toggleCustom.OnValueChanged.AddListener(Select);
        }

        private void OnDisable()
        {
            _toggleCustom.OnValueChanged.RemoveListener(Select);
        }

        private void Select(bool value)
        {
            if (!value) return;
            _eventsService.OnChangedColor(_colorPreset);
        }
    }
}