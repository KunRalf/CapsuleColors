using System.Collections.Generic;
using GameLogic.DataObjects.Objects;
using UnityEngine;

namespace GameLogic.Station.Biliboard
{
    public class BillboardController : MonoBehaviour
    {
        [SerializeField] private BillboardColorCountPrefab _prefab;
        [SerializeField] private Transform _spawnPlace;
        
        private List<BillboardColorCountPrefab> _pool = new List<BillboardColorCountPrefab>();

        public void Init(List<ColorPreset> colorPresets)
        {
            Dictionary<ColorPreset, int> colorsCount = new Dictionary<ColorPreset, int>();
            foreach (var preset in colorPresets)
            {
                if (colorsCount.ContainsKey(preset))
                {
                    colorsCount[preset]++;
                }
                else
                {
                    colorsCount.Add(preset,1);
                }
            }

            InstantiateCounts(colorsCount);
        }

        private void InstantiateCounts(Dictionary<ColorPreset, int> colorsCount)
        {
            foreach (var color in colorsCount)
            {
                var prefab = Instantiate(_prefab, _spawnPlace);
                prefab.Init(color.Key.Color,color.Value);
            }
        }
    }
}