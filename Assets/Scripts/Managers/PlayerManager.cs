using System;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour, IManagerProperties
    {
        public static PlayerManager Instance;
        public GameObject PlayerGO;
        
        [SerializeField] GameObject playerPrefab;

        private void OnEnable()
        {
            LevelManager.Instance.OnLevelLoaded += OnLevelLoaded;
        }

        private void OnDisable()
        {
            LevelManager.Instance.OnLevelLoaded -= OnLevelLoaded;
        }
        
        private void Awake()
        {
            SetInstance();
        }
        

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

        private void OnLevelLoaded()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Transform spawnLocation = LevelManager.Instance.LevelSpawnManager.GetSpawnPoint();
            PlayerGO = Instantiate(playerPrefab, spawnLocation.position, spawnLocation.rotation);
            MenuManager.Instance.SwitchToHUD();
        }
    }
}