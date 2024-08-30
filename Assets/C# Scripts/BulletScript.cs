using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f; // Damage dealt by the bullet

    private void Start()
    {
        // Ignore collision with the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Collider2D playerCollider = player.GetComponent<Collider2D>();
            Collider2D bulletCollider = GetComponent<Collider2D>();
            if (playerCollider != null && bulletCollider != null)
            {
                Physics2D.IgnoreCollision(bulletCollider, playerCollider);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet hits a mob
        MobHealth mob = collision.GetComponent<MobHealth>();
        if (mob != null)
        {
            // Apply damage to the mob
            mob.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            // If the bullet hits something other than a mob, destroy the bullet
            Destroy(gameObject);
        }
    }
}