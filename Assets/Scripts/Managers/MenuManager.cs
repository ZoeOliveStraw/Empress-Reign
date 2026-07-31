using System;
using System.Collections;
using UnityEngine;

namespace Managers
{
    public class MenuManager : MonoBehaviour, IManagerProperties
    {
        public static MenuManager Instance;

        [SerializeField] public UI_LoadingShade loadingShade;
        [SerializeField] public GameObject mainMenu;
        [SerializeField] public GameObject levelSelectMenu;
        [SerializeField] public GameObject studioSplash;
        [SerializeField] public GameObject HUD;

        private GameObject currentMenu = null;
        
        private float fadeDuration = 1f;
        private float fadeTimer;
        private float startAlpha;
        private float targetAlpha;

        private bool isFading;

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
                Debug.Log("Instance already set");
                Destroy(gameObject);
            }
            isLoaded = true;
        }

        private void Awake()
        {
            SetInstance();
        }

        public void InitialLoad()
        {
            StartCoroutine(DoInitialLoad());
        }

        private IEnumerator DoInitialLoad()
        {
            loadingShade.gameObject.SetActive(true);
            studioSplash.SetActive(true);
            mainMenu.SetActive(false);
            loadingShade.FadeIn(2, false);
            yield return new WaitForSeconds(5);
            loadingShade.FadeOut(2, false);
            yield return new WaitForSeconds(2);
            studioSplash.SetActive(false);
            mainMenu.SetActive(true);
            loadingShade.FadeIn(2, false);
            currentMenu = mainMenu;
            loadingShade.gameObject.SetActive(false);
        }

        public void LoadLevelSelectMenu()
        {
            currentMenu.SetActive(false);
            levelSelectMenu.SetActive(true);
            currentMenu = levelSelectMenu;
        }

        public void LoadMainMenu()
        {
            currentMenu.SetActive(false);
            mainMenu.SetActive(true);
            currentMenu = mainMenu;
        }
    }
}