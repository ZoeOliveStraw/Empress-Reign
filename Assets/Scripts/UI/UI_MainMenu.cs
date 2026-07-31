using System;
using Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] private Button btnNewGame;
    [SerializeField] private Button btnLoadGame;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;

    private void OnEnable()
    {
        btnNewGame.onClick.AddListener(() => NewGameClicked());
        btnLoadGame.onClick.AddListener(() => LoadGameClicked());
        btnSettings.onClick.AddListener(() => SettingsClicked());
        btnCredits.onClick.AddListener(() => CreditsClicked());
    }

    private void NewGameClicked()
    {
        MenuManager.Instance.LoadLevelSelectMenu();
    }

    private void LoadGameClicked()
    {
        
    }

    private void SettingsClicked()
    {
        
    }

    private void CreditsClicked()
    {
        
    }
}
