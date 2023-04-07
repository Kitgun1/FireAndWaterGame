using NaughtyAttributes;
using UnityEngine;

namespace FireAndWater.Level
{
    [RequireComponent(typeof(Collider2D))]
    public class SpecialDoor : Door
    {
        [SerializeField, Layer] private int _layer;

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != _layer) return;

            Inside();
        }

        protected override void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer != _layer) return;

            Outside();
        }
    }
}