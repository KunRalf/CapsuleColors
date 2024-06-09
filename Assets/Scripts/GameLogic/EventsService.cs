using System;
using GameLogic.DataObjects.Objects;
using UnityEngine;

namespace GameLogic
{
    public class EventsService
    {
        public event Action<ColorPreset> ChangedColor;
        public event Action<bool, int> PlatformOnStation;

        public void OnChangedColor(ColorPreset color)
        {
            ChangedColor?.Invoke(color);
        }

        public void OnPlatformOnStation(bool value, int id)
        {
            PlatformOnStation?.Invoke(value, id);
        }
    }
}