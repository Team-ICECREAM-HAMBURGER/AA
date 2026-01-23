using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class TurretFireMissile : ITurretFire {
    private TurretData turretData;  // <- TurretController
    
    
    public void Init(TurretData turretData) {
        this.turretData = turretData;
        
        // Object Pooling
    }

    public void Fire(Transform origin, Vector3 direction) {
        throw new System.NotImplementedException();
    }

    public void StopFire() {
        throw new System.NotImplementedException();
    }
}