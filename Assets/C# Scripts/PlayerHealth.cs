using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 5; // Maximum number of lives the player has
    private int currentLives; // Current number of lives the player has

    void Start()
    {
        // Initialize the player's lives
        currentLives = maxLives;
    }

    // Method to apply damage to the player
    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        Debug.Log("Player hit! Lives remaining: " + currentLives);

        // Check if the player's lives have reached zero
        if (currentLives <= 0)
        {
            Die();
        }
    }

    // Method to handle the player's death
    private void Die()
    {
        Debug.Log("Player has died!");
        // Destroy the player GameObject
        Destroy(gameObject);

        // Additional logic for player death (e.g., game over screen) can be added here
    }
}