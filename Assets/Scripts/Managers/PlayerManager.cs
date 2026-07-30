using System;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour, IManagerProperties
    {
        public static PlayerManager Instance;
        public GameObject PlayerGO;
        
        [SerializeField] GameObject playerPrefab;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
        }
        
        private bool isLoaded;
        bool IManagerProperties.IsLoaded => isLoaded;
        void IManagerProperties.SetInstance()
        {
            SetInstance();
        }
        private void SetInstance()
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

        private void Update()
        {
            if (PlayerGO == null)
            {
                PlayerGO = GameObject.FindGameObjectWithTag("Player");
            }
        }
    }
}