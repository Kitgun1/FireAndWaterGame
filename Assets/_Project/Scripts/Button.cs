using System.Collections.Generic;
using UnityEngine;

namespace FireAndWater
{
    public class Button : MonoBehaviour
    {
        [HideInInspector] public bool Pressed = false;

        private List<GameObject> _inside = new List<GameObject>();

        private void Start()
        {
            Pressed = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _inside.Add(collision.gameObject);

            if (_inside.Count > 0 && Pressed == false)
            {
                Pressed = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (_inside.Remove(collision.gameObject) && _inside.Count == 0 && Pressed == true)
            {
                Pressed = false;
            }
        }
    }
}