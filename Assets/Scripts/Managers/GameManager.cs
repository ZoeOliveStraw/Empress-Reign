using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] public MenuManager menuManager;
        [SerializeField] public PlayerManager playerManager;
        [SerializeField] public ItemManager itemManager;
        [SerializeField] public LevelManager levelManager;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            InitializeManagers();
            StartGame();
        }

        private void InitializeManagers()
        {
            menuManager.SetInstance();
            playerManager.SetInstance();
            itemManager.SetInstance();
            levelManager.SetInstance();
            
            Debug.Log("Managers Initialized");
        }

        private void StartGame()
        {
            Debug.Log("Calling Initial load");
            MenuManager.Instance.InitialLoad();
        }
    }
}