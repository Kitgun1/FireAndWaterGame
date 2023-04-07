using System.Collections;
using UnityEngine;

namespace FireAndWater.Entities
{
    public class Lava : Trap
    {
        protected override IEnumerator DealDamage(DamageInfo damageCell)
        {
            return base.DealDamage(damageCell);
        }
    }
}