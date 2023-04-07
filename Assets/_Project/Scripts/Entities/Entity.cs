using UnityEngine;
using UnityEngine.SceneManagement;

namespace FireAndWater.Entities
{
    public abstract class Entity : MonoBehaviour, IDamagable
    {
        protected int MaxHealth;
        protected int Health;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Entity entity))
            {
                OnEntityEntered2D(entity);
            }
        }

        protected abstract void OnEntityEntered2D(Entity entity);

        public virtual void ApplyDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }

        public virtual void Die()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}