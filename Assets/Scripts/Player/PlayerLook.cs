using System;
using UnityEngine;

namespace Player
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        [SerializeField] private Transform cam;
        [SerializeField] private Transform camAnchor;
        [SerializeField] private float bobMaximum;
        [SerializeField] private float bobSpeed;
        [SerializeField] private float currentBob;
        [SerializeField] private bool ascending = true;
        
        private float _yaw;
        private float _currentMoveSpeed;
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

        public void Look(Vector2 lookVector)
        {
            float mouseX = lookVector.x * Time.deltaTime * stats.LookSpeed;
            float mouseY = lookVector.y * Time.deltaTime * stats.LookSpeed;

            // accumulate pitch
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            // apply pitch to camera anchor
            camAnchor.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

            // apply yaw to player body
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
