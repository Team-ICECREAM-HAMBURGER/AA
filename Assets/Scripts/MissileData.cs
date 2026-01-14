using UnityEngine;

[CreateAssetMenu(fileName = "MissileData_", menuName = "ScriptableObjects/MissileData", order = 1)]
public class MissileData : ScriptableObject {
    public float dmg;
    public float speed;
    public AudioClip sfx;
}