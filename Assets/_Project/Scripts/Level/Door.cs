using UnityEngine;
using UnityEngine.Events;

namespace FireAndWater.Level
{
    public abstract class Door : MonoBehaviour
    {
        public event UnityAction OnInside;
        public event UnityAction OnOutside;

        protected abstract void OnTriggerEnter2D(Collider2D collision);

        protected abstract void OnTriggerExit2D(Collider2D collision);

        protected virtual void Inside()
        {
            OnInside?.Invoke();
        }

        protected virtual void Outside()
        {
            OnOutside?.Invoke();
        }
    }
}