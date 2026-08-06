using Managers;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        LevelManager.Instance.ReturnToMainMenu();
    }
}
