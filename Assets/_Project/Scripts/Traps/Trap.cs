using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;

namespace FireAndWater.Entities
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Trap : MonoBehaviour
    {
        [SerializeField, Layer] protected int Layer;
        [SerializeField] protected int Damage = 1;
        [SerializeField] protected float Cooldown = 1;

        private List<DamageInfo> _damagables = new List<DamageInfo>();

        private void Start()
        {
            gameObject.layer = Layer;

            GetComponent<Collider2D>().isTrigger = true;
        }

        protected virtual IEnumerator DealDamage(DamageInfo damageCell)
        {
            while (true)
            {
                damageCell.Damagable.ApplyDamage(damageCell.Damage);
                yield return new WaitForSeconds(damageCell.Cooldown);
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == Layer)
            {
                if (collision.TryGetComponent(out IDamagable damagable))
                {
                    DamageInfo damageCell = new DamageInfo(damagable, Damage, Cooldown);
                    IEnumerator courotine = DealDamage(damageCell);
                    _damagables.Add(damageCell);

                    damageCell.AddCourotine(courotine);
                    StartCoroutine(courotine);
                }
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == Layer)
            {
                if (collision.TryGetComponent(out IDamagable damagable))
                {
                    DamageInfo damageCell = _damagables.Where(d => d.Damagable == damagable).FirstOrDefault();

                    StopCoroutine(damageCell.Courotine);
                    damageCell.RemoveCourotine();
                    _damagables.Remove(damageCell);
                }
            }
        }
    }
}