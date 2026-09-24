using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private float velocity = 5f;
    [SerializeField] private Vector3 direction = Vector3.forward;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBox), 0f, spawnInterval);
    }

    private void SpawnBox()
    {
        GameObject box = Instantiate(
            boxPrefab,
            transform.position,
            transform.rotation
        );

        Rigidbody rb = box.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * velocity;
        }
    }
}