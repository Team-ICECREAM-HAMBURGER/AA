using UnityEngine;

public interface IInputProvider {
    Vector2 GetAimDirection();
    bool isFirePressed();
    bool isSwitchPressed();
    void Dispose();
}