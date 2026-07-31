using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SO_SceneRegistry", menuName = "Scriptable Objects/SO_SceneRegistry")]
    public class SO_SceneRegistry : ScriptableObject
    {
        [Tooltip("Name of the scene in the build index")]
        [SerializeField] public string sceneName;
        [Tooltip("Name of the level for players")]
        [SerializeField] public string sceneTitle;
        [SerializeField] public Sprite previewImage;
    }
}
