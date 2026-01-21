using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : GCSingletonImplementer<PlayerInputController> {
    private IInputProvider _inputProvider;
    private Dictionary<GCEnumManager.TURRET_TYPE, List<TurretController>> _turretMap = new();
    
    private Vector3 turretAimDirection;
    private bool isFiring;
    private bool isSwitching;
    private GCEnumManager.TURRET_TYPE currentType;
    
    
    private void Init() {
        this.currentType = GCEnumManager.TURRET_TYPE.NORMAL; 
        this._inputProvider = PlayerInputManager.Instance.CurrentInputProvider;
    }
    
    private void Start() {
        Init();
    }

    private void Update() {
        if (this._inputProvider == null) return;
        
        InputControl();
    }

    private void InputControl() {
        // Input init; Strategy
        this.turretAimDirection = this._inputProvider.GetAimDirection();
        this.isFiring = this._inputProvider.isFirePressed();
        this.isSwitching = this._inputProvider.isSwitchPressed();
        
        // Input
        if (this.turretAimDirection != Vector3.zero) {  // Joystick
            RotateTurrets(this.turretAimDirection);
        }

        if (this.isFiring) {    // Press A
            FireTurrets();
        }
        
        if (this.isSwitching) { // Press B
            SwitchTurretMode();
        }
    }
    
    public void RegisterTurret(TurretController turret, GCEnumManager.TURRET_TYPE type) {
        if (!this._turretMap.ContainsKey(type)) {
            this._turretMap[type] = new();
        }
        
        this._turretMap[type].Add(turret);
    }

    public void UnregisterTurret(TurretController turret, GCEnumManager.TURRET_TYPE type) {
        if (!this._turretMap.ContainsKey(type)) return;
        
        this._turretMap[type].Remove(turret);
    }

    private void RotateTurrets(Vector3 aimDirection) {
        // // TODO: 딕셔너리 내에 있는 터릿들을 foreach()로 회전
        // if (aimDirection == Vector3.zero) return;
        //
        // foreach (var turret in this._turretMap[this.currentType]) {
        //     turret.Rotate(aimDirection);
        // }
    }

    private void FireTurrets() {
        // TODO: 딕셔너리 내에 있는 터릿들이 공격
    }

    private void SwitchTurretMode() {
        // TODO: 딕셔너리의 Key를 이용해서 다음 터릿(묶음)으로 전환
    }
}