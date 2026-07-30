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
        [SerializeField] public GameObject studioSplash;
        
        private float fadeDuration = 1f;
        private float fadeTimer;
        private float startAlpha;
        private float targetAlpha;

        private bool isFading;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        private bool isLoaded;
        bool IManagerProperties.IsLoaded => isLoaded;
        void IManagerProperties.SetInstance()
        {
            SetInstance();
        }
        private void SetInstance()
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

        public IEnumerator LoadMainMenu()
        {
            studioSplash.SetActive(true);
            mainMenu.SetActive(false);
            loadingShade.FadeIn(2, false);
            yield return new WaitForSeconds(5);
            loadingShade.FadeOut(2, false);
            yield return new WaitForSeconds(2);
            studioSplash.SetActive(false);
            mainMenu.SetActive(true);
            loadingShade.FadeIn(2, false);
        }
    }
}