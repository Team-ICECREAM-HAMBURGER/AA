using UnityEngine;

[CreateAssetMenu(fileName = "TurretFireData_", menuName = "ScriptableObjects/TurretFireData", order = 1)]
public class TurretFireData : ScriptableObject {
    public float rpm;
    public float dmg;
    public GameObject projectilePrefab;
    public GCEnumManager.TURRET_TYPE turretType;
}