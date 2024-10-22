using PrimeTween;
using UnityEngine;

public class MovementAction : GameKitObject
{
    public float moveSpeed = 0.5f;
    public float rotateSpeed = 2f;
    public Vector3 targetVector = new Vector3();
    protected float moveDuration = 0.2f;
    public void MoveForward() => MoveForward(moveSpeed);
    public void MoveBackward() => MoveBackward(moveSpeed);
    public void MoveLeft() => MoveLeft(moveSpeed);
    public void MoveRight() => MoveRight(moveSpeed);
    public void RotateRight() => RotateRight(rotateSpeed);
    public void RotateLeft() => RotateLeft(rotateSpeed);
    public void RotateY() => RotateY(rotateSpeed);

    public void RotateXFromVector(){
        if(rotateTween.isAlive){
            rotateTween.Stop();
        }
        Tween.Rotation(transform, Quaternion.Euler(targetVector.x, targetVector.y, targetVector.z), 1/rotateSpeed);
    }

    public void RotateYFromVector(){
        if(rotateTween.isAlive){
            rotateTween.Stop();
        }
        Tween.Rotation(transform, Quaternion.Euler(targetVector.x, targetVector.y, targetVector.z),1/rotateSpeed);
    }

    public void RotateZFromVector(){
        if(rotateTween.isAlive){
            rotateTween.Stop();
        }
        Tween.Rotation(transform, Quaternion.Euler(targetVector.x, targetVector.y, targetVector.z), 1/rotateSpeed);
    }

    public void SetVectorX(float x){
        targetVector.x = x;
    }

    public void SetVectorY(float y){
        targetVector.y = y;
    }

    public void SetVectorZ(float z){
        targetVector.z = z;
    }
    public void MoveToPlayer(){
        if(positionTween.isAlive){
            positionTween.Stop();
        }
        var player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log($"Player name:, {player.name}, {player.transform.position}");
        if(player){
            positionTween = Tween.Position(transform, player.transform.position, 1f/moveSpeed);
        }
    }

    public void MoveToObjectWithTag(string tag){
        if(positionTween.isAlive){
            positionTween.Stop();
        }

        var objTag = GameObject.FindGameObjectWithTag(tag);
        if(objTag){
            positionTween = Tween.Position(transform, objTag.transform.position, 1f/moveSpeed);
        }
    }
}
