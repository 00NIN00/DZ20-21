using UnityEngine;

public class ShooterExplosion : IShooter
{
    private float _explosionRadius;
    private float _explosionForce;
    private float _upwardsModifier = 1;

    public ShooterExplosion(float radius, float force)
    {
        _explosionRadius = radius;
        _explosionForce = force;
    }
    
    private Camera Camera => Camera.main;
    
    public void Cast(Vector2 position)
    {
        Ray ray = Camera.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.name);
            
            if (hit.collider != null)
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, _explosionRadius);
                
                foreach (Collider nearbyObject in colliders)
                {
                    Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            
                    if (rb != null)
                    {
                        rb.AddExplosionForce(_explosionForce, hit.point, _explosionRadius, _upwardsModifier, ForceMode.Impulse);
                    }
                }
            }
        }
    }
}