using UnityEngine;
public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject _replacement;
    [SerializeField] private float _breakForce = 2;
    [SerializeField] private float _collisionMultiplier = 100;
    [SerializeField] private bool _broken;

    public bool IsBroken => _broken;

    void OnCollisionEnter(Collision collision)
    {
        if (_broken) return;
        if (collision.relativeVelocity.magnitude >= _breakForce)
        {
            Break(collision.contacts[0].point, collision.relativeVelocity.magnitude * _collisionMultiplier);
        }
    }

    /// <summary>
    /// Triggers the break with no real collision data available (e.g. selection-based breaking).
    /// Uses the object's own position as the explosion point.
    /// </summary>
    public void BreakFromSelection()
    {
        if (_broken) return;
        Break(transform.position, _breakForce * _collisionMultiplier);
    }

    private void Break(Vector3 explosionPoint, float explosionForce)
    {
        if (_broken) return;
        _broken = true;

        var replacement = Instantiate(_replacement, transform.position, transform.rotation);

        var rbs = replacement.GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.AddExplosionForce(explosionForce, explosionPoint, 2);
        }

        Destroy(gameObject);
    }
}