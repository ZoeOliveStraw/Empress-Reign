using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SO_MasterSceneList", menuName = "Scriptable Objects/SO_MasterSceneList")]
    public class SO_MasterSceneList : ScriptableObject
    {
        [SerializeField] public List<SO_SceneRegistry> scenes;
    }
}
