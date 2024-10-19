using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        IHealth health = other.GetComponent<IHealth>();
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}
