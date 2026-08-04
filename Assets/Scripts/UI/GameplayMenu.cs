using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class GameplayMenu : MonoBehaviour
    {
        [SerializeField] private List<GameplayMenuTab> menuTabs;
        private int currentTabIndex = 0;

        private InputSystem_Actions _input;

        private void Awake()
        {
            _input = new InputSystem_Actions();
        }

        private void Start()
        {
            _input.UI.TabLeft.performed += ctx => ChangeTab(-1);
            _input.UI.TabRight.performed += ctx => ChangeTab(1);
        }

        private void ChangeTab(int increment)
        {
            currentTabIndex += increment;
            if(currentTabIndex >= menuTabs.Count) currentTabIndex = 0;
            if(currentTabIndex < 0) currentTabIndex = menuTabs.Count - 1;
            OpenTab(currentTabIndex);
        }
        
        public void OpenTab(int tabToOpen)
        {
            for (int i = 0; i < menuTabs.Count; i++) menuTabs[i].gameObject.SetActive(i == tabToOpen);
        }
        
        private void OnEnable()
        {
            OpenTab(currentTabIndex);
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}
