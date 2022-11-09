using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health;
    public Slider CarHealth;

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        CarHealth.value = health;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
