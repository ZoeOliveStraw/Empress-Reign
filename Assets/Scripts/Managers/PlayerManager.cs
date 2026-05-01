using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        
        [SerializeField] GameObject playerPrefab;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
        }
    }
}