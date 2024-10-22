using PrimeTween;
using UnityEngine;

public class MovementAction : GameKitObject
{
    public float moveSpeed = 0.5f;
    public float rotateSpeed = 2f;
    protected float moveDuration = 0.2f;
    public void MoveForward() => MoveForward(moveSpeed);
    public void MoveBackward() => MoveBackward(moveSpeed);
    public void MoveLeft() => MoveLeft(moveSpeed);
    public void MoveRight() => MoveRight(moveSpeed);
    public void RotateRight() => RotateRight(rotateSpeed);
    public void RotateLeft() => RotateLeft(rotateSpeed);
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
