using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnerAction : MonoBehaviour
{
    public GameObject objectToSpawn;
    private BoxCollider spawnArea;

    protected GameObject lastSpawn;
    private void Awake() {
        spawnArea = GetComponent<BoxCollider>();
        spawnArea.isTrigger = true;
    }
    private void OnValidate() {
        spawnArea = GetComponent<BoxCollider>();
        spawnArea.isTrigger = true;
    }

    public virtual void RendomSpawn()
    {
        Vector3 center = spawnArea.bounds.center;
        Vector3 size = spawnArea.bounds.size;

        float xPos = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float yPos = Random.Range(center.y - size.y / 2, center.y + size.y / 2);
        float zPos = Random.Range(center.z - size.z / 2, center.z + size.z / 2);
        Vector3 spawnPosition = new Vector3(xPos, yPos, zPos);

        lastSpawn = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }
    public virtual void SpawnWithPosition(Vector3 position) {
        lastSpawn = Instantiate(objectToSpawn, position, Quaternion.identity);
    }
}
