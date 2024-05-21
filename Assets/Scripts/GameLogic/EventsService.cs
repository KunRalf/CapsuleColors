using System;
using UnityEngine;

namespace GameLogic
{
    public class EventsService
    {
        public event Action<Color> ChangedColor;

        public void OnChangedColor(Color color)
        {
            ChangedColor?.Invoke(color);
        }
    }
}