using UnityEngine;
using UnityEngine.Pool;

public class TurretFireMissileStrategy : ITurretFireStrategy {
    private TurretFireData turretFireData;  // <- TurretController
    
    
    public void Init(TurretFireData turretFireData) {
        this.turretFireData = turretFireData;
        
        // Object Pooling
    }

    public void Fire(Transform origin, Transform target) {
        throw new System.NotImplementedException();
    }

    public void StopFire() {
        throw new System.NotImplementedException();
    }
}