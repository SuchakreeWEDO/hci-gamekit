using EditorCools;
using UnityEngine;

public class SpawnerWithForceAction: SpawnerAction{
	private Rigidbody rb;
	public Vector3 velocity;
	private void Awake() {
	}

	[Button("RandomSpawn")]
    public override void RendomSpawn()
    {
        base.RendomSpawn();
		rb = lastSpawn.GetComponent<Rigidbody>();
		if(!rb)
			rb = lastSpawn.AddComponent<Rigidbody>();
		rb.AddForce(velocity);
    }

    public override void SpawnWithPosition(Vector3 position)
    {
        base.SpawnWithPosition(position);
		rb = lastSpawn.GetComponent<Rigidbody>();
		if(!rb)
			rb = lastSpawn.AddComponent<Rigidbody>();
		rb.AddForce(velocity);
    }
}