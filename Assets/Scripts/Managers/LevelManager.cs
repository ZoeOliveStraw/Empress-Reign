using System;
using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager : MonoBehaviour, IManagerProperties
    {
        public static LevelManager Instance;
        private Scene bootstrapScene;
        private Scene loadedScene;

        public LevelSpawnManager LevelSpawnManager => FindObjectOfType<LevelSpawnManager>();
        
        public Action OnStartUnloadLevel;
        public Action OnLevelUnloaded;
        public Action OnStartLoadLevel;
        public Action OnLevelLoaded;
        public Action OnReturnToMainMenu;
        
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
        
        private void Awake()
        {
            SetInstance();
        }

        private void Start()
        {
            bootstrapScene = SceneManager.GetActiveScene();
            SceneManager.SetActiveScene(SceneManager.GetActiveScene());
        }

        public void LoadLevel(string sceneName)
        {
            Debug.LogWarning($"Loading level: {sceneName}");
            StartCoroutine(LoadLevelScene(sceneName));
        }

        private IEnumerator LoadLevelScene(string sceneName)
        {
            MenuManager.Instance.loadingShade.FadeOut(2);
            yield return new WaitForSeconds(2);
            if (loadedScene.isLoaded)
            {
                OnStartUnloadLevel?.Invoke();
                AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(loadedScene);
                while (unloadOp != null && !unloadOp.isDone) yield return null;
                OnLevelUnloaded?.Invoke();
            }
            OnStartLoadLevel?.Invoke();
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (op != null && !op.isDone)
            {
                yield return null;
            }
            loadedScene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(loadedScene);
            MenuManager.Instance.loadingShade.FadeIn(2);
            OnLevelLoaded?.Invoke();
        }

        public void ReturnToMainMenu()
        {
            StartCoroutine(DoReturnToMainMenu());
        }
        
        private IEnumerator DoReturnToMainMenu()
        {
            MenuManager.Instance.loadingShade.FadeOut(2);
            yield return new WaitForSeconds(2);
            if (loadedScene.isLoaded)
            {
                OnStartUnloadLevel?.Invoke();
                AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(loadedScene);
                while (unloadOp != null && !unloadOp.isDone) yield return null;
                OnLevelUnloaded?.Invoke();
            }
            
            OnReturnToMainMenu?.Invoke();
        }
    }
}
