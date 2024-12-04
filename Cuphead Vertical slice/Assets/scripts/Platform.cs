using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of movement
    [SerializeField] private float timeA = 1f; // Minimum time to move up
    [SerializeField] private float timeB = 3f; // Maximum time to move up
    [SerializeField] private float deathSpeed = 2f; // Speed of movement when dying
    [SerializeField] private float despawnTime = 2f; // Time before the platform despawns

    private bool isMoving = true;

    void Start()
    {
        // Get a random time between timeA and timeB
        float moveTime = Random.Range(timeA, timeB);
        StartCoroutine(MoveUpForTime(moveTime));
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            Die();
        }

        if (isMoving)
        {
            // Move the object straight up
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private IEnumerator MoveUpForTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        isMoving = false; // Stop moving after the duration
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Die();
        }
    }

    private void Die()
    {
        // Start moving the platform down
        StartCoroutine(MoveDownAndDespawn());
    }

    private IEnumerator MoveDownAndDespawn()
    {
        while (true)
        {
            // Move the object straight down
            transform.Translate(Vector2.down * deathSpeed * Time.deltaTime);
            yield return null;
        }

        // Wait for a short time before despawning
        yield return new WaitForSeconds(despawnTime);

        // Destroy the platform game object
        Destroy(gameObject);
    }
}
