using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class PhysicAction : GameKitObject
{

    private Rigidbody rb;
    private Collider c;
    public bool useGavity = false;
    public bool trigger = true;
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
}
