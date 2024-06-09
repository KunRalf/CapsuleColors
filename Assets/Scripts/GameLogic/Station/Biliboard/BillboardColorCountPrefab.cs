using GameLogic.DataObjects.Objects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.Station.Biliboard
{
    public class BillboardColorCountPrefab : MonoBehaviour
    {
        [SerializeField] private Image _colorImage;
        [SerializeField] private TextMeshProUGUI _countText;

        public void Init(Color color, int count)
        {
            _colorImage.color = color;
            _countText.text = $"x{count}";
        }
    }
}