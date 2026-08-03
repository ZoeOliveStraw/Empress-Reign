using Data;
using Managers;
using UnityEngine;

namespace Ability_System.Tasks
{
    public class AbilityTaskLoadLevel : AbilityTask
    {
        [SerializeField] private SO_SceneRegistry sceneToLoad; 
        protected override void Execute()
        {
            base.Execute();
            LevelManager.Instance.LoadLevel(sceneToLoad.sceneName);
        }
    }
}