using UnityEngine;

public class forward : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Translate(Vector3.forward * 1f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 1f * Time.deltaTime);
    }
}
