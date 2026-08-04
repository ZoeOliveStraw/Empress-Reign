using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public enum GameState
    {
        MainMenu,
        Gameplay,
        GameplayMenu,
        Paused
    }
    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] public MenuManager menuManager;
        [SerializeField] public PlayerManager playerManager;
        [SerializeField] public ItemManager itemManager;
        [SerializeField] public LevelManager levelManager;

        public GameState gameState;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else Destroy(this);
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            Debug.Log("Calling Initial load");
            MenuManager.Instance.InitialLoad();
            gameState = GameState.MainMenu;
        }
    }
}