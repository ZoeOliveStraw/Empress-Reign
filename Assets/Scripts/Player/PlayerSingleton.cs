using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class PlayerSingleton : MonoBehaviour
    {
        public static PlayerSingleton Instance;

        private void Start()
        {
            if(Instance == null) Instance = this;
            else Destroy(this.gameObject);
        }
    }
}