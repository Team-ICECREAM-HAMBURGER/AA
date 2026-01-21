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
    
    public void Rotate(Vector3 aimDirection) {
        // if (aimDirection == Vector3.zero) return;
        //
        // var maxRotationAngle = 45f;
        // aimDirection.x *= maxRotationAngle;
        // var targetRotation = Quaternion.Euler(-aimDirection.x, 0, 0);
        //
        // this.transform.rotation = Quaternion.Slerp(
        //     this.transform.rotation, 
        //     targetRotation, 
        //     this.turretData.rotateSpeed * Time.deltaTime);
    }
}