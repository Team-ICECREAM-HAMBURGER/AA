using UnityEngine;

public class TurretFireLaser : ITurretFire {
    private TurretData turretData;  // <- TurretController

    
    public void Init(TurretData turretData) {
        this.turretData = turretData;
    }

    public void Fire(Transform origin, Vector3 direction) {
        throw new System.NotImplementedException();
    }

    public void StopFire() {
        throw new System.NotImplementedException();
    }
}