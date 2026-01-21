using UnityEngine;

[CreateAssetMenu(fileName = "TurretData_", menuName = "ScriptableObjects/TurretData", order = 1)]
public class TurretData : ScriptableObject {
    public float rpm;
    public float dmg;
    public float rotateMaxAngle;
    public float rotateSpeed;
    public GameObject projectilePrefab;
    public GCEnumManager.TURRET_TYPE turretType;
}