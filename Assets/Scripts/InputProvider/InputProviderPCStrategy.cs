using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProviderPCStrategy : IInputProvider {
    private const float MOUSE_SENSITIVITY = 0.1f;
    private const float LOOK_DISTANCE = 1000.0f;
    
    private InputSystemPC _pcInputSystem;
    private Vector3 _pivotPosition;
    private float _currentPitch;
    
    
    public InputProviderPCStrategy(Camera mainCamera, Vector3 playerPosition) {
        this._pcInputSystem = new();
        this._pcInputSystem.TurretControl.Enable();
        this._pivotPosition = playerPosition;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    public Vector3 GetAimWorldPosition() {
        var mouseDelta = this._pcInputSystem.TurretControl.Aim.ReadValue<Vector2>();

        this._currentPitch += mouseDelta.y * MOUSE_SENSITIVITY;
        this._currentPitch = Mathf.Clamp(this._currentPitch, -4f, 80f);

        var radians = this._currentPitch * Mathf.Deg2Rad;
        var y = Mathf.Sin(radians);
        var z = Mathf.Cos(radians);
        var lookDirection = new Vector3(0, y, z);

        return this._pivotPosition + (lookDirection * LOOK_DISTANCE);
    }
    
    public bool isFirePressed() {
        var fireButton = this._pcInputSystem.TurretControl.Fire.IsPressed();
        
        return fireButton;
    }
    
    public bool isSwitchPressed() {
        var switchButton = this._pcInputSystem.TurretControl.Switch.WasPressedThisFrame();
        
        return switchButton;
    }

    public void Dispose() {
        this._pcInputSystem.TurretControl.Disable();
        this._pcInputSystem.Dispose();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}