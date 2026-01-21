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
        if (PlayerInputController.Instance == null) return;
        
        PlayerInputController.Instance.UnregisterTurret(this, this.turretFireData.turretType);
    }

    public void Fire(Vector3 direction) {
        var origin = (this.firePoint != null) ? this.firePoint : this.transform;
        this.turretFire.Fire(origin, direction);
    }

    public void StopFire() {
        this.turretFire.StopFire();
    }

    // public void Rotate(Vector3 aimDirection) {
    //     this.transform.rotation = Quaternion.RotateTowards(
    //         this.transform.rotation, 
    //         Quaternion.LookRotation(aimDirection), 
    //         this.turretFireData.rotateSpeed + Time.deltaTime);
    // }
    
    public void Rotate(Vector3 aimDirection) {
        if (aimDirection == Vector3.zero) return;

        var maxRotationAngle = 45f;
        aimDirection.x *= maxRotationAngle;
        // 2. 2D 평면 환경(X, Y축 사용)에서 회전은 Z축을 기준으로 돌아야 합니다.
        var targetRotation = Quaternion.Euler(-aimDirection.x, 0, 0);

        // 3. rotateSpeed에 Time.deltaTime을 곱하여 부드럽게 회전
        this.transform.rotation = Quaternion.Slerp(
            this.transform.rotation, 
            targetRotation, 
            this.turretFireData.rotateSpeed * Time.deltaTime);
    }
}