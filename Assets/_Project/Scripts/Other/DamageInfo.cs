using System.Collections;

namespace FireAndWater
{
    public class DamageInfo
    {
        public IDamagable Damagable { get; private set; }
        public int Damage { get; private set; }
        public float Cooldown { get; private set; }
        public IEnumerator Courotine { get; private set; }

        public DamageInfo(IDamagable damagable, int damage, float coolDown)
        {
            Damagable = damagable;
            Damage = damage;
            Cooldown = coolDown;
            Courotine = null;
        }

        public void AddCourotine(IEnumerator corotine)
        {
            Courotine = corotine;
        }

        public void RemoveCourotine()
        {
            Courotine = null;
        }
    }
}
