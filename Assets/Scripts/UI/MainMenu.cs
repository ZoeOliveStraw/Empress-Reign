using System;
using Managers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button btnNewGame;
    [SerializeField] private Button btnLoadGame;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;

    private void Start()
    {
        btnNewGame.onClick.AddListener(() => NewGameClicked());
        btnLoadGame.onClick.AddListener(() => LoadGameClicked());
        btnSettings.onClick.AddListener(() => SettingsClicked());
        btnCredits.onClick.AddListener(() => CreditsClicked());
    }

    private void NewGameClicked()
    {
        LevelManager.Instance.LoadLevel("Dev Gym");
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
