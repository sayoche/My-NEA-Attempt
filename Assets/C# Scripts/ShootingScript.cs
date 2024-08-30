using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 2f;
    public Sprite bulletSprite;
    public float fireRate = 0.1f; // Time between shots in seconds

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // Left mouse button
        {
            FireBullet();
            nextFireTime = Time.time + fireRate; // Set the next fire time
        }
    }

    void FireBullet()
    {
        // Calculate the mouse position in world space
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction from the fire point to the mouse position
        Vector3 direction = (worldMousePosition - firePoint.position).normalized;

        // Create a new bullet GameObject
        GameObject bullet = new GameObject("Bullet");
        bullet.transform.position = firePoint.position;

        // Add a SpriteRenderer component
        SpriteRenderer spriteRenderer = bullet.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = bulletSprite;

        // Add a Rigidbody2D component
        Rigidbody2D rb = bullet.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        // Set the velocity in the direction of the mouse position with the specified bullet speed
        rb.velocity = direction * bulletSpeed;

        // Add a BoxCollider2D component for collision detection
        BoxCollider2D collider = bullet.AddComponent<BoxCollider2D>();
        collider.isTrigger = true; // Use a trigger for simpler collision handling

        // Add a Bullet component to handle collision
        bullet.AddComponent<Bullet>();

        // Destroy the bullet after a certain time
        Destroy(bullet, bulletLifetime);
    }
}
