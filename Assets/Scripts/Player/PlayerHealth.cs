using System;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : Health
    {
        [SerializeField] private HUD_Meter healthMeter;

        private void Start()
        {
            healthMeter.Set(currentHealth, maxHealth);
        }

        public override void TakeDamage(int damage, DamageType damageType = DamageType.Normal)
        {
            base.TakeDamage(damage, damageType);
            healthMeter.Initialize(currentHealth, 0, maxHealth);
        }
    }
}
