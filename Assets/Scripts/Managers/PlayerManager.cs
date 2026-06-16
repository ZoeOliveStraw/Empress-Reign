using System;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
        public GameObject PlayerGO;
        
        [SerializeField] GameObject playerPrefab;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(this);
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