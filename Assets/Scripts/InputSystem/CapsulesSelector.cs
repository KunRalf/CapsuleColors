using System;
using GameLogic;
using GameLogic.Platforms;
using UnityEditor.Media;
using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class CapsulesSelector : MonoBehaviour
    {
        private Camera _camera;
        private Color _color;
        private EventsService _eventsService;


        [Inject]
        public void Construct(EventsService eventsService)
        {
            _eventsService = eventsService;
        }
        
        private void OnEnable()
        {
            _eventsService.ChangedColor += ColorChange;
        }

        private void OnDisable()
        {
            _eventsService.ChangedColor -= ColorChange;
        }

        private void ColorChange(Color color)
        {
            _color = color;
        }
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                DetectObject(Input.mousePosition);
            } 
        }

        private void DetectObject(Vector3 mousePos)
        {
            Ray mouseRay = _camera.ScreenPointToRay(mousePos);
            RaycastHit hit;
            bool hasTarget = Physics.Raycast(mouseRay, out hit);
            if (!hasTarget) return;
            if (hit.transform.TryGetComponent<PlatformTile>(out var tile))
            {
               tile.SetTileColor(_color);
            }
        }
    }
}