using System.Collections;
using UnityEngine;

public class TurretFireNormal : ITurretFire {
    private bool isFiring;
    private float nextFireTime; // 다음 발사 가능 시간
    private TurretData turretData;  // <- TurretController
    
    
    public void Init(TurretData turretData) {
        this.turretData = turretData;
    }

    public void Fire(Transform origin, Vector3 direction) {
        if (Time.time < this.nextFireTime) return;
        
        TurretProjectileSpawnController.Instance.Get(GCEnumManager.TURRET_TYPE.NORMAL, origin.position, 
            Quaternion.LookRotation(direction));
        
        this.nextFireTime = Time.time + (60f / this.turretData.rpm);
    }
    
    public void StopFire() {
        throw new System.NotImplementedException();
    }
}