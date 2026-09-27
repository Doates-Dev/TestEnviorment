using UnityEngine;
using UnityEngine.VFX;

public class VFXOnCollision : MonoBehaviour
{
    public GameObject vfxPrefab; // prefab with VisualEffect component

    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        GameObject fx = Instantiate(vfxPrefab, contact.point, Quaternion.LookRotation(contact.normal));
        fx.GetComponent<VisualEffect>().Play();
        Destroy(fx, 3f); // clean up after the effect finishes
    }
}