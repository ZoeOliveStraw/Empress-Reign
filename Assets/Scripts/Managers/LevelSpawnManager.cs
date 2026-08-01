using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managers
{
    [Serializable]
    public struct SpawnPoint
    {
        public string spawnPointName;
        public Transform transform;
    }
    
    public class LevelSpawnManager : MonoBehaviour
    {
        public static LevelSpawnManager Instance;

        [SerializeField] private List<SpawnPoint> spawnPoints;

        public void SetInstance()
        {
            Instance = this;
        }

        public Transform GetSpawnPoint()
        {
            return spawnPoints[0].transform;
        }
        
        public Transform GetSpawnPoint(string name)
        {
            foreach(SpawnPoint sp in spawnPoints) { if (sp.spawnPointName == name) return sp.transform; }
            return null;
        }

        public Transform GetSpawnPoint(int index)
        {
            return spawnPoints[index].transform;
        }
    }
}
