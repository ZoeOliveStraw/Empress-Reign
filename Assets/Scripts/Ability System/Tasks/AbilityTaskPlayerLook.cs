using Ability_System;
using Player;
using UnityEngine;

public class AbilityTaskPlayerLook : AbilityTask
{
    [SerializeField] private float lookSensitivity;
    private Transform camAnchor;
    private Transform playerBody;
    private float _yaw;
    private float _xRotation = 0f;
    
    private void Start()
    {
        CursorManager();
    }

    private void CursorManager()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    protected override void Execute()
    {
        base.Execute();
        if (camAnchor == null)
        {
            camAnchor = myAbility.myActor.GetComponent<PlayerController>().cameraAnchor;
        }
        if (playerBody == null)
        {
            playerBody = myAbility.myActor.transform;
        }
        Look(myAbility.myParams.Axis2D);
    }

    public void Look(Vector2 lookVector)
    {
        float mouseX = lookVector.x * Time.deltaTime * lookSensitivity;
        float mouseY = lookVector.y * Time.deltaTime * lookSensitivity;

        // accumulate pitch
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        // apply pitch to camera anchor
        camAnchor.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // apply yaw to player body
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
