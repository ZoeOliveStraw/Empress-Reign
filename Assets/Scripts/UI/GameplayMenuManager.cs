using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class GameplayMenuManager : MonoBehaviour
    {
        [SerializeField] private bool isPaused;
        [SerializeField] private GameObject GameplayMenu;

        private InputSystem_Actions _input;

        private void Awake()
        {
            _input = new InputSystem_Actions();
        }

        private void Start()
        {
            _input.UI.Menu.performed += ctx => TogglePause();
        }

        private void TogglePause()
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            GameplayMenu.SetActive(isPaused);
            if (isPaused)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }
    }
}
