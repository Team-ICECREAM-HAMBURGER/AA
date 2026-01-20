using UnityEngine;

public class TurretFireShotgun : ITurretFire {
    private TurretFireData turretFireData;  // <- TurretController

    
    public void Init(TurretFireData turretFireData) {
        this.turretFireData = turretFireData;
    }

    public void Fire(Transform origin, Vector3 direction) {
        throw new System.NotImplementedException();
    }

    public void StopFire() {
        throw new System.NotImplementedException();
    }
}