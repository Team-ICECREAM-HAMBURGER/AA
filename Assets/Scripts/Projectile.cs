using System;
using UnityEngine;

public class Projectile : MonoBehaviour {
    private Rigidbody _projectileRB;


    private void Init() {
        this._projectileRB = GetComponent<Rigidbody>();
    }

    private void Awake() {
        Init();
    }

    private void OnEnable() {
        Debug.Log(this.transform.forward);  // TODO: 총알이 머즐의 정면으로 날아가게 수정
        this._projectileRB.linearVelocity = this.transform.forward * 100f;
    }
}