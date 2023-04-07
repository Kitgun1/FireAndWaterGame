using FireAndWater.Entities;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

namespace FireAndWater
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float _speed = 2.0f;
        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;
        [SerializeField] private List<Button> _buttons = new List<Button>();
        [SerializeField] private Vector2 _sizeCast = Vector2.zero;

        [Layer] public int Layer;

        private bool _isWork = false;

        void Update()
        {
            bool temp = false;
            foreach (var button in _buttons)
            {
                if (button.Pressed == true) temp = true;
            }
            _isWork = temp;

            if (_isWork && transform.position != _pointB.position)
            {
                MoveForward();
            }
            else if (!_isWork && transform.position != _pointA.position)
            {
                MoveBackward();
            }
        }
        private void MoveForward()
        {
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
        }

        private void MoveBackward()
        {
            bool isPlayer = false;
            RaycastHit2D[] hit = Physics2D.BoxCastAll(transform.position, new Vector2(_sizeCast.x * 0.9f, _sizeCast.y / 2), 0f, Vector2.down, _sizeCast.y * 1);
            for (int i = 0; i < hit.Length; i++)
            {
                if (hit[i].collider.TryGetComponent(out PlayerEntity player))
                {
                    isPlayer = true;
                }
            }
            if (!isPlayer)
            {
                transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
            }
        }
    }
}