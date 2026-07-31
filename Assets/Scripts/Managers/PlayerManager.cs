using System;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour, IManagerProperties
    {
        public static PlayerManager Instance;
        public GameObject PlayerGO;
        
        [SerializeField] GameObject playerPrefab;
        
        private bool isLoaded;
        public bool IsLoaded => isLoaded;
        public  void SetInstance()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            isLoaded = true;
        }
    }
}