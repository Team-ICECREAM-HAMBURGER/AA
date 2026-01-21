using UnityEngine;

public class TurretProjectileSpawnController : 
    GCObjectPoolController<TurretProjectileSpawnController, GCEnumManager.TURRET_TYPE, Projectile> {
    [SerializeField] private Projectile normalProjectile;
    [SerializeField] private Projectile laserProjectile;
    [SerializeField] private Projectile shotgunProjectile;
    [SerializeField] private Projectile missileProjectile;
    
    // 일반 발사체를 현재 위치와 회전값으로 생성
    // Projectile projectile = TurretProjectileSpawnController.Instance.Get(
    //     GCEnumManager.TURRET_TYPE.NORMAL, 
    //     firePoint.position, 
    //     firePoint.rotation
    // );
    
    // GCObjectPoolController에 이 메서드가 있는지 확인하거나 추가해야 합니다.
    // public virtual void Release(Tenum type, Tobject obj) {
    //     if (this._poolDic.ContainsKey(type)) {
    //         this._poolDic[type].Release(obj);
    //     }
    // }
    
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
        // 초기화 로직; 
    }

    private void Awake() {
        InitPool(GCEnumManager.TURRET_TYPE.NORMAL);
        InitPool(GCEnumManager.TURRET_TYPE.LASER);
        InitPool(GCEnumManager.TURRET_TYPE.SHOTGUN);
        InitPool(GCEnumManager.TURRET_TYPE.MISSILE);
    }
}