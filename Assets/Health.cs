using UnityEngine;

public class Health : MonoBehaviour
{
    public HealthBar healthBar = null;
    private int hp = 400;

    private void Start()
    {
        healthBar?.SetMaxHealth(hp);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        healthBar?.SetHealth(hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
