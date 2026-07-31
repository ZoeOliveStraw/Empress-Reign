using System;
using System.Collections.Generic;
using Data;
using Managers;
using UnityEngine;

namespace UI
{
    public class UI_MenuSceneList : MonoBehaviour
    {
        [SerializeField] SO_MasterSceneList mastersceneList;
        [SerializeField] private GameObject sceneWidgetPrefab;
        [SerializeField] private Transform sceneListParent;
        private List<GameObject> sceneWidgets;

        private void OnEnable()
        {
            if(sceneWidgets.Count > 0) ClearSceneWidgets();
            CreateSceneWidgets();
        }
        
        private void OnDisable()
        {
            ClearSceneWidgets();
        }

        private void ClearSceneWidgets()
        {
            foreach (var go in sceneWidgets)
            {
                Destroy(go);
            }
            sceneWidgets.Clear();
        }

        private void CreateSceneWidgets()
        {
            foreach (var scene in mastersceneList.scenes)
            {
                sceneWidgets.Add(CreateSceneWidget(scene));
            }
        }

        private GameObject CreateSceneWidget(SO_SceneRegistry scene)
        {
            UI_WidgetSceneButton go = Instantiate(sceneWidgetPrefab, sceneListParent).GetComponent<UI_WidgetSceneButton>();
            go.Initialize(scene);
            return go.gameObject;
        }

        public void BackToMainMenu()
        {
            MenuManager.Instance.LoadMainMenu();
        }
    }
}
