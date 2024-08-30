using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int attackDamage = 1; // Damage dealt by the enemy
    public float attackCooldown = 2f; // Time between attacks in seconds
    private float nextAttackTime = 0f; // Time when the enemy can attack again

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null && Time.time >= nextAttackTime)
            {
                Debug.Log("Enemy attacking player!");
                // Attack the player with the specified damage
                playerHealth.TakeDamage(attackDamage);
                nextAttackTime = Time.time + attackCooldown; // Set the next attack time
            }
        }
    }
}