using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] public GameObject mainMenu;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            StartCoroutine(MenuManager.Instance.LoadMainMenu());
        }
    }
}
