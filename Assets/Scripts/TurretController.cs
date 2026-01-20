using System;
using UnityEngine;
using System.Reflection;

public class TurretController : MonoBehaviour {
    [SerializeField] private Transform firePoint;
    [SerializeField] private TurretFireData turretFireData; // SO
    
    private ITurretFire turretFire;


    private void Init() {
        // Reflection
        var className = "TurretFire" + this.turretFireData.turretType.ToString() + "Strategy";
        var classType = Type.GetType(className);

        if (classType == null) return;

        this.turretFire = (ITurretFire)Activator.CreateInstance(classType);
        this.turretFire.Init(this.turretFireData);
    }

    private void OnEnable() {
        PlayerInputController.Instance.RegisterTurret(this, this.turretFireData.turretType);
    }

    private void Awake() {
        Init();
    }

    private void OnDisable() {
        PlayerInputController.Instance.UnregisterTurret(this, this.turretFireData.turretType);
    }

    public void Fire(Vector3 direction) {
        var origin = (this.firePoint != null) ? this.firePoint : this.transform;
        this.turretFire.Fire(origin, direction);
    }

    public void StopFire() {
        this.turretFire.StopFire();
    }
}