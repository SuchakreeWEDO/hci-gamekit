using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public enum PhysicActionType
{
    enter,
    stay,
    exit,
}

[Serializable]
public class PhysicEventInfo
{
    public string tagName = "Enermy";
    public PhysicActionType actionType = PhysicActionType.enter;
    public UnityEvent action;
}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PhysicEvent : GameKitObject
{
    private Rigidbody rb;
    private Collider c;
    public bool useGavity = false;
    public bool trigger = true;
    public List<PhysicEventInfo> info = new List<PhysicEventInfo>();
    public override void Awake() {
        base.Awake();
        Setup();
    }
    private void OnValidate() {
        Setup();
    }

    private void Setup() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = useGavity;

        c = GetComponent<Collider>();
        c.isTrigger = trigger;
    }
    public void AddForceForward(float value = 1) {
        rb.AddForce(transform.forward * value);
    }

    public void AddForceBackward(float value = 1) {
        rb.AddForce(-transform.forward * value);
    }

    public void AddForceLeft(float value = 1) {
        rb.AddForce(-transform.right * value);
    }

    public void AddForceRight(float value = 1) {
        rb.AddForce(transform.right * value);
    }
    private void OnCollisionEnter(Collision other) {
        var eventList = info.Where(x => x.actionType == PhysicActionType.enter).ToArray();
        for (int i = 0; i < eventList.Length; i++)
        {
            var physicEvent = eventList[i];
            if(other.gameObject.tag == physicEvent.tagName){
                var gkObject = GetComponent<GameKitObject>();
                gkObject.hitOtherEnter = other.gameObject;
                Debug.Log($"gkObject:{gkObject}, other.gameObject");
                physicEvent?.action?.Invoke();
                gkObject.hitOtherEnter = null;
                // Debug.Log($"Event enter {i}");
            }
        }
    }

    private void OnCollisionStay(Collision other) {
        var eventList = info.Where(x => x.actionType == PhysicActionType.stay).ToArray();
        for (int i = 0; i < eventList.Length; i++)
        {
            var physicEvent = eventList[i];
            if(other.gameObject.tag == physicEvent.tagName){
                var gkObject = GetComponent<GameKitObject>();
                gkObject.hitOtherStay = other.gameObject;
                physicEvent?.action?.Invoke();
                gkObject.hitOtherStay = null;
                // Debug.Log($"Event stay {i}");
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        var eventList = info.Where(x => x.actionType == PhysicActionType.exit).ToArray();
        for (int i = 0; i < eventList.Length; i++)
        {
            var physicEvent = eventList[i];
            if(other.gameObject.tag == physicEvent.tagName){
                var gkObject = GetComponent<GameKitObject>();
                gkObject.hitOtherExit = other.gameObject;
                physicEvent?.action?.Invoke();
                gkObject.hitOtherExit = null;
                // Debug.Log($"Event Exit {i}");
            }
        }
    }


    private void OnTriggerEnter(Collider other) {
        var eventList = info.Where(x => x.actionType == PhysicActionType.enter).ToArray();
        for (int i = 0; i < eventList.Length; i++)
        {
            var physicEvent = eventList[i];
            if(other.gameObject.tag == physicEvent.tagName){
                var gkObject = GetComponent<GameKitObject>();
                gkObject.hitOtherEnter = other.gameObject;
                Debug.Log($"gkObject:{gkObject}, other.gameObject");
                physicEvent?.action?.Invoke();
                gkObject.hitOtherEnter = null;
                // Debug.Log($"Event enter {i}");
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        var eventList = info.Where(x => x.actionType == PhysicActionType.stay).ToArray();
        for (int i = 0; i < eventList.Length; i++)
        {
            var physicEvent = eventList[i];
            if(other.gameObject.tag == physicEvent.tagName){
                var gkObject = GetComponent<GameKitObject>();
                gkObject.hitOtherStay = other.gameObject;
                physicEvent?.action?.Invoke();
                gkObject.hitOtherStay = null;
                // Debug.Log($"Event stay {i}");
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        var eventList = info.Where(x => x.actionType == PhysicActionType.exit).ToArray();
        for (int i = 0; i < eventList.Length; i++)
        {
            var physicEvent = eventList[i];
            if(other.gameObject.tag == physicEvent.tagName){
                var gkObject = GetComponent<GameKitObject>();
                gkObject.hitOtherExit = other.gameObject;
                physicEvent?.action?.Invoke();
                gkObject.hitOtherExit = null;
                // Debug.Log($"Event Exit {i}");
            }
        }
    }

    public void DestroyThisObject(){
        Destroy(gameObject);
    }
}
