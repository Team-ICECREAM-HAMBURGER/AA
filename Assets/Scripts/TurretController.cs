using System;
using UnityEngine;
using System.Reflection;

public class TurretController : MonoBehaviour {
    [SerializeField] private Transform firePoint;
    [SerializeField] private TurretData turretData; // SO
    
    private ITurretFire turretFire;


    private void Init() {
        // Reflection
        var className = "TurretFire" + this.turretData.turretType.ToString() + "Strategy";
        var classType = Type.GetType(className);

        if (classType == null) return;

        this.turretFire = (ITurretFire)Activator.CreateInstance(classType);
        this.turretFire.Init(this.turretData);
    }

    private void OnEnable() {
        PlayerInputController.Instance.RegisterTurret(this, this.turretData.turretType);
    }

    private void Awake() {
        Init();
    }

    private void OnDisable() {
        if (PlayerInputController.Instance == null) return;
        
        PlayerInputController.Instance.UnregisterTurret(this, this.turretData.turretType);
    }

    public void Fire(Vector3 direction) {
        var origin = (this.firePoint != null) ? this.firePoint : this.transform;
        this.turretFire.Fire(origin, direction);
    }

    public void StopFire() {
        this.turretFire.StopFire();
    }

    public void Rotate(Vector3 aimPosition) {
        var turretPosition = this.transform.position;
        aimPosition.x = turretPosition.x;

        var direction = (aimPosition - turretPosition);

        if (direction != Vector3.zero) {
            this.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}