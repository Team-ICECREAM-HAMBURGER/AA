using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MissileController : MonoBehaviour {
    [SerializeField] private MissileData missileData;
    
    [Space(25f)]
    
    [SerializeField] private GameObject missileObject;
    [SerializeField] private Rigidbody missileRB;
    [Space(10f)]
    [SerializeField] private ParticleSystem missileFX;
    [SerializeField] private ParticleSystem explosionFX;
    
    
    private bool _isHit;
    private Transform _target;
    private GameObject[] _potentialTargets;
    private Vector3 _targetDirection;
    
    
    private void Init() {
        this._isHit = false;
        this.missileObject.SetActive(true);
        this.missileFX.Play();
        this.explosionFX.Stop();

        this.missileRB.constraints = RigidbodyConstraints.FreezeRotation;
        
        this._potentialTargets = GameObject.FindGameObjectsWithTag("Player");
        
        if (this._potentialTargets is null) return;
        
        var index = Random.Range(0, this._potentialTargets.Length);
        this._target = this._potentialTargets[index].transform;
    }

    private void Awake() {
        Init();
    }

    private void OnEnable() {
        Init();
    }

    private void FixedUpdate() {
        Launch();
    }

    private void Update() {
        RotateToTarget();
    }

    private void RotateToTarget() {
        if (this._isHit) return;
        if (this._target is null) return;

        this._targetDirection = (this._target.position - this.transform.position).normalized;
        
        if (this._targetDirection != Vector3.zero) {
            this.transform.rotation = Quaternion.LookRotation(this._targetDirection);
        }
    }
    
    private void Launch() {
        if (this._isHit) return;
        if (this._target is null) return;
        
        this.missileRB.linearVelocity = this.transform.forward * this.missileData.speed;
    }

    private void OnCollisionEnter(Collision other) {
        this._isHit = true;
        this.missileRB.isKinematic = true;
        
        // TODO: DMG
        
        this.missileObject.SetActive(false);
        this.missileFX.Stop();
        this.explosionFX.Play();
    }
}
