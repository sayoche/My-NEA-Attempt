using UnityEngine;

public class MobHealth : MonoBehaviour
{
    public float maxHealth = 10f; // Maximum health of the mob
    private float currentHealth;   // Current health of the mob

    void Start()
    {
        // Initialize the mob's health
        currentHealth = maxHealth;
    }

    // Method to apply damage to the mob
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Check if the mob's health has reached zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to check if the mob is still alive
    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    // Method to handle the mob's death
    private void Die()
    {
        // Destroy the mob GameObject
        Destroy(gameObject);

        // Additional logic for when the mob dies (e.g., play animation, drop loot, etc.)
    }
}