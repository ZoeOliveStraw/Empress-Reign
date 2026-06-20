using UnityEngine;

namespace Ability_System
{
    public class MainHand : MonoBehaviour
    {
        private GameObject myOwner;
        private GameObject mainHandAbilityGO;
        private Ability mainHandAbility;

        public void UseMainHandAbility()
        {
            if(mainHandAbility != null) mainHandAbility.Use(new AbilityParams(gameObject));
        }

        public void EquipMainHandAbility(GameObject abilityGO)
        {
            UnequipMainHandAbility();
            GameObject mainHandAbilityGO = Instantiate(abilityGO, transform.position, Quaternion.identity);
            mainHandAbilityGO.transform.SetParent(transform);
            mainHandAbility = mainHandAbilityGO.GetComponent<Ability>();
        }

        public void UnequipMainHandAbility()
        {
            if (mainHandAbilityGO != null)
            {
                mainHandAbility = null;
                Destroy(mainHandAbilityGO);
            }
        }
    }
}
