using UnityEngine;
using PrimeTween;
using UnityEngine.Events;
using UniRx;

public class GameKitObject: MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetPosition;
    protected Tween rotateTween;
    protected Tween positionTween;
    protected Tween positionHTween;
    [HideInInspector]
    public GameObject hitOtherEnter;
    [HideInInspector]
    public GameObject hitOtherExit;
    [HideInInspector]
    public GameObject hitOtherStay;
    public void DestroySelf(){
        Destroy(gameObject);
    }

    public virtual void Awake() {
    }

    public virtual void Start() {
    }

    public virtual void Update() {
    }

    public void DestroyHitOtherEnter(){
        Debug.Log($"DestroyHitOtherEnter start {hitOtherEnter}");
        if(hitOtherEnter){
            Debug.Log("DestroyHitOtherEnter in if");
            Destroy(hitOtherEnter);
        }
    }

    public void DestroyHitOtherExit(){
        if(hitOtherEnter)
            Destroy(hitOtherExit);
    }

    public void DestroyHitOtherStay(){
        if(hitOtherEnter)
            Destroy(hitOtherStay);
    }

    public void MoveForward(float _moveSpeed = 0.5f) {
        Debug.Log($"MoveForward: {_moveSpeed}");
        if(positionTween.isAlive){
            positionTween.Stop();
        }
        positionTween = Tween.Position(transform, transform.position+transform.forward * _moveSpeed, 0.2f);
    }

    public void MoveBackward(float _moveSpeed = 0.5f) {
        if(positionTween.isAlive){
            positionTween.Stop();
        }
        positionTween = Tween.Position(transform, transform.position-transform.forward * _moveSpeed, 0.2f);
    }

    public void MoveLeft(float _moveSpeed = 0.5f) {
        if(positionHTween.isAlive){
            positionHTween.Stop();
        }
        positionHTween = Tween.Position(transform, transform.position-transform.right * _moveSpeed, 0.2f);
    }

    public void MoveRight(float _moveSpeed = 0.5f) {
        if(positionHTween.isAlive){
            positionHTween.Stop();
        }
        positionHTween = Tween.Position(transform, transform.position+transform.right * _moveSpeed, 0.2f);
    }
    public void RotateRight(float _rotateSpeed = 2f) {
        if(rotateTween.isAlive){
            rotateTween.Stop();
        }
        Tween.Rotation(transform, transform.rotation * Quaternion.Euler(0, 5*_rotateSpeed, 0), 0.2f);
    }
    public void RotateLeft(float _rotateSpeed = 2f) {
        if(rotateTween.isAlive){
            rotateTween.Stop();
        }
        Tween.Rotation(transform, transform.rotation * Quaternion.Euler(0, -5*_rotateSpeed, 0), 0.2f);
    }
}
