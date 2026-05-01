using System;
using Interactables;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class GameplayMenuTab : MonoBehaviour
{
    public UI_Navigation defaultSelection;

    private UI_Navigation currentSelection;

    private InputSystem_Actions _input;

    private void Awake()
    {
        _input = new InputSystem_Actions();
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
