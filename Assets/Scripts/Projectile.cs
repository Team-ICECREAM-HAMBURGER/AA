using System;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private Rigidbody projectileRB;
    [SerializeField] private Transform projectileTF; 
    
    
    private void OnEnable() {
        // this.projectileRB.AddRelativeForce(this.projectileTF.up * 10f, ForceMode.Impulse);
    }

    private void Update() {
        Debug.Log(this.projectileTF.up);
    }
}