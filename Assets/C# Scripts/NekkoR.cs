using UnityEngine;

public class EnemyFollowAndFlip : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float speed = 0.1f; // Speed at which the enemy moves towards the player
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Flip the sprite based on the direction
            if (direction.x > 0)
            {
                spriteRenderer.flipX = true; // Face left
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = false; // Face right
            }
        }
    }
}
