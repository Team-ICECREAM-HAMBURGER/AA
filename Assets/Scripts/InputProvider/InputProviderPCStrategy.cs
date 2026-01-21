using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputProviderPCStrategy : IInputProvider {
    private InputSystemPC _pcInputSystem;
    private Camera _mainCamera;
    private Vector3 _playerPosition;
    
    
    public InputProviderPCStrategy(Camera mainCamera, Vector3 playerPosition) {
        this._pcInputSystem = new();
        this._pcInputSystem.TurretControl.Enable();

        this._mainCamera = mainCamera;
        this._playerPosition = playerPosition;
    }
    
    public Vector3 GetAimDirection() {
        Vector2 centerPosition = this._mainCamera.WorldToScreenPoint(this._playerPosition);
        var aimPosition = this._pcInputSystem.TurretControl.Aim.ReadValue<Vector2>();
        var aimDirection = (aimPosition - centerPosition).normalized;
        
        return aimDirection;
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
    }
}