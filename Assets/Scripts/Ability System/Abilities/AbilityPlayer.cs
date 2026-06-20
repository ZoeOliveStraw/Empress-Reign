using Player;

namespace Ability_System.Abilities
{
    public class AbilityPlayer : Ability
    {
        private SO_PlayerStats stats;
        
        protected override void Start()
        {
            base.Start();
            TryGetStats();
        }

        protected void TryGetStats()
        {
            if(abilityOwner != null) stats = abilityOwner.GetComponent<PlayerStats>().stats;
        }

        public void Use(AbilityParams abilityParams = default)
        {
            if (stats == null) TryGetStats();
            base.Use(abilityParams);
        }
    }
}
