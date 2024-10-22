using UnityEngine;
using PrimeTween;

public class CustomMovement : GameKitObject
{
    public float speed = 0.2f;
    public float duration = 0.2f;
    public void MovePositionForward() {
        Tween.Position(transform, (transform.position+transform.forward) * speed, duration);
    }
    public void RotateRight() {
        Tween.Rotation(transform, transform.rotation * Quaternion.Euler(0, speed, 0), duration);
    }
    public void RotateLeft() {
        Tween.Rotation(transform, transform.rotation * Quaternion.Euler(0, -speed, 0), duration);
    }
}
