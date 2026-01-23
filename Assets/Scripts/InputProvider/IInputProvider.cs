using UnityEngine;

public interface IInputProvider {
    Vector3 GetAimWorldPosition();
    bool isFirePressed();
    bool isSwitchPressed();
    void Dispose();
}