using UnityEngine;

public class DammageCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(100);
        }
    }
}
