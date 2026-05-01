using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance;
        private Scene loadedScene;
    
        [SerializeField] private GameObject player;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }

        public GameObject GetPlayer()
        {
            return player;
        }

        public IEnumerator LoadLevelScene(string sceneName)
        {
            MenuManager.Instance.loadingShade.FadeOut(2);
            yield return new WaitForSeconds(2);
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (op != null && !op.isDone)
            {
                yield return null;
            }
            GameManager.Instance.mainMenu.SetActive(false);
            loadedScene = UnityEngine.SceneManagement.SceneManager.GetSceneByName(sceneName);
            MenuManager.Instance.loadingShade.FadeIn(2);
        }
    }
}
