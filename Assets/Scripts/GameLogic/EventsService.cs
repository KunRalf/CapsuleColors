using System;
using GameLogic.DataObjects.Objects;
using UnityEngine;

namespace GameLogic
{
    public class EventsService
    {
        public event Action<ColorPreset> ChangedColor;

        public void OnChangedColor(ColorPreset color)
        {
            ChangedColor?.Invoke(color);
        }
    }
}