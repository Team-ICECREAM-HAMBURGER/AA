using UnityEngine;

public interface ITurretFire {
    public void Init(TurretFireData turretFireData);
    public void Fire(Transform origin, Vector3 direction);
    public void StopFire();
}