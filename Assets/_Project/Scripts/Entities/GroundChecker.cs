using NaughtyAttributes;
using UnityEngine;

namespace FireAndWater.Entities
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField, Layer] private int _layer;

        public bool IsGround = true;

        private void Update()
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(0.95f, 0.9f), 0f, Vector2.down, 0.1f, _layer);
            if (hit)
            {
                IsGround = true;
            }
            else
            {
                IsGround = false;
            }
        }
    }
}