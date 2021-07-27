using UnityEngine;

public class Health : MonoBehaviour
{
    private int hp = 100;
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
