using UnityEngine;
using PrimeTween;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetPosition = new Vector3(0, 1, -2);
    public Quaternion offsetQUanternion;
    public float speed = 0.1f; 
    public bool lookAt = true;
    public Tween followTween;
    private void Update() {
        if(followTween.isAlive){
            followTween.Stop();
        }
        if(target){
            followTween = Tween.Position(transform, target.position + offsetPosition, speed);
            if(lookAt)
                transform.LookAt(target.transform);
        }
    }
}
