using UnityEngine;
using UnityEngine.Pool;

public class TurretFireMissile : ITurretFire {
    private TurretFireData turretFireData;  // <- TurretController
    
    
    public void Init(TurretFireData turretFireData) {
        this.turretFireData = turretFireData;
        
        // Object Pooling
    }

    public void Fire(Transform origin, Vector3 direction) {
        throw new System.NotImplementedException();
    }

    public void StopFire() {
        throw new System.NotImplementedException();
    }
}