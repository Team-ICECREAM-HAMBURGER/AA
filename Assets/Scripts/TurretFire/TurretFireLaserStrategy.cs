using UnityEngine;

public class TurretFireLaserStrategy : ITurretFireStrategy {
    private TurretFireData turretFireData;  // <- TurretController

    
    public void Init(TurretFireData turretFireData) {
        this.turretFireData = turretFireData;
    }

    public void Fire(Transform origin, Transform target) {
        throw new System.NotImplementedException();
    }

    public void StopFire() {
        throw new System.NotImplementedException();
    }
}