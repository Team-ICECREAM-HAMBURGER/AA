using UnityEngine;

public interface IInputProvider {
    Vector3 GetAimDirection();
    bool isFirePressed();
    bool isSwitchPressed();
    void Dispose();
}