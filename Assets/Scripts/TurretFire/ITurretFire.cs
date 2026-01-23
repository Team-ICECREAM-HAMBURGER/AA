using System.Collections;
using UnityEngine;

public interface ITurretFire {
    public void Init(TurretData turretData);
    public void Fire(Transform origin, Vector3 direction);
    public void StopFire();
}