using System;
using UnityEngine;

public class TurretController : MonoBehaviour {
    [SerializeField] private Transform turretHead;
    [SerializeField] private Transform firePoint;
    [SerializeField] private TurretData turretData; // SO
    
    private ITurretFire turretFire;


    private void Init() {
        // Reflection
        var className = "TurretFire" + this.turretData.turretType.ToString();
        var classType = Type.GetType(className, false, true);

        if (classType == null) {
            Debug.Log("!!");
            return;
        }

        this.turretFire = (ITurretFire)Activator.CreateInstance(classType);
        this.turretFire.Init(this.turretData);
    }

    private void OnEnable() {
        PlayerInputController.Instance.RegisterTurret(this, this.turretData.turretType);
    }

    private void Awake() {
        Init();
    }

    private void Update() {
        Debug.DrawLine(this.turretHead.transform.position, 
            this.turretHead.position + this.turretHead.forward * 100f, Color.brown);
    }

    private void OnDisable() {
        if (PlayerInputController.Instance == null) return;
        
        PlayerInputController.Instance.UnregisterTurret(this, this.turretData.turretType);
    }

    public void Fire() {
        var origin = (this.firePoint != null) ? this.firePoint : this.transform;
        var target = this.turretHead.position + this.turretHead.forward * 100f;

        var aim = (target - origin.position).normalized;
        
        this.turretFire.Fire(origin, aim);
    }

    public void StopFire() {
        this.turretFire.StopFire();
    }

    public void Rotate(Vector3 aimPosition) {
        var turretPosition = this.transform.position;
        aimPosition.x = turretPosition.x;

        var direction = (aimPosition - turretPosition);

        if (direction != Vector3.zero) {
            this.turretHead.rotation 
                = Quaternion.RotateTowards(this.turretHead.rotation, Quaternion.LookRotation(direction), 
                    this.turretData.rotateSpeed * Time.deltaTime);
        }
    }
}