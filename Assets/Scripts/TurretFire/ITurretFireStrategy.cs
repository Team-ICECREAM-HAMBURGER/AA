using UnityEngine;

public interface ITurretFireStrategy {
    public void Init(TurretFireData turretFireData);
    public void Fire(Transform origin, Transform target);
    public void StopFire();
}