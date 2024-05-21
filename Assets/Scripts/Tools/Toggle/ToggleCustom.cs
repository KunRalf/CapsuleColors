using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Tools.Toggle
{
    public class ToggleCustom : MonoBehaviour, IPointerClickHandler
    {
        [Serializable]
        public class ToggleCustomEvent : UnityEvent<bool>
        {}
        [SerializeField] private bool _isInteractable;
        [SerializeField] private bool _isOn;
        [SerializeField] private ToggleGroupCustom _toggleGroup;

        [SerializeField] private bool _isOneState;
        
        [SerializeField] private GameObject _onStateGO;
        [SerializeField] private GameObject _offStateGO;

        public ToggleCustomEvent OnValueChanged = new ToggleCustomEvent();
        
        private void OnEnable()
        {
            OnValueChanged.AddListener((bool x) => Set(x));
            SetToggleGroup(_toggleGroup, false);
        }

        private void OnDisable()
        {
            OnValueChanged.RemoveListener((bool x) => Set(x));
            SetToggleGroup(null, false);
        }

        private void OnValidate()
        {
            PlayEffect(_isOn);
        }

        public bool IsOn
        {
            get { return _isOn; }

            set
            {
                Set(value);
            }
        }
        
        
        private void Set(bool value, bool sendCallback = true)
        {
            if (_isOn == value)
                return;
            _isOn = value;
            if (_toggleGroup != null && _toggleGroup.isActiveAndEnabled && IsActive())
            {
                if (_isOn || (!_toggleGroup.AnyTogglesOn() && !_toggleGroup.IsAllowSwitchOff))
                {
                    _isOn = true;
                    _toggleGroup.NotifyToggleOn(this, sendCallback);
                }
            }

            PlayEffect(_isOn);
            
            if (sendCallback && _isOn)
            {
                OnValueChanged?.Invoke(_isOn);
            }
        }

        private void PlayEffect(bool value)
        {
            if (_isOneState)
            {
                _onStateGO.SetActive(value);
            }
        }
        
        private void SetToggleGroup(ToggleGroupCustom newGroup, bool setMemberValue)
        {
            if (_toggleGroup != null)
                _toggleGroup.UnregisterToggle(this);
            
            if (setMemberValue)
                _toggleGroup = newGroup;

            if (newGroup != null && IsActive())
                newGroup.RegisterToggle(this);

            if (newGroup != null && _isOn && IsActive())
                newGroup.NotifyToggleOn(this);
        }
        
        public void SetIsOnWithoutNotify(bool value)
        {
            Set(value, false);
        }
        
        private bool IsActive()
        {
            return gameObject.activeSelf && enabled;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Set(!_isOn);
        }
    }
}