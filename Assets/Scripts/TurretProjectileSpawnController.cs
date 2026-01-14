using UnityEngine;

public class TurretProjectileSpawnController : 
    GCObjectPoolController<TurretProjectileSpawnController, GCEnumManager.TURRET_TYPE, Projectile> {
    [SerializeField] private Projectile normalProjectile;
    [SerializeField] private Projectile laserProjectile;
    [SerializeField] private Projectile shotgunProjectile;
    [SerializeField] private Projectile missileProjectile;
    
    
    protected override Projectile GetPrefab(GCEnumManager.TURRET_TYPE type) {
        return type switch {
            GCEnumManager.TURRET_TYPE.NORMAL => this.normalProjectile,
            GCEnumManager.TURRET_TYPE.LASER => this.laserProjectile,
            GCEnumManager.TURRET_TYPE.SHOTGUN => this.shotgunProjectile,
            GCEnumManager.TURRET_TYPE.MISSILE => this.missileProjectile,
            _ => null
        };
    }

    protected override void OnCreateObject(GCEnumManager.TURRET_TYPE type, Projectile obj) {
        // obj.Init(this._poolDic[type]);  // TODO: InitPool()
    }

    private void Awake() {
        InitPool(GCEnumManager.TURRET_TYPE.NORMAL);
        InitPool(GCEnumManager.TURRET_TYPE.LASER);
        InitPool(GCEnumManager.TURRET_TYPE.SHOTGUN);
        InitPool(GCEnumManager.TURRET_TYPE.MISSILE);
    }
}