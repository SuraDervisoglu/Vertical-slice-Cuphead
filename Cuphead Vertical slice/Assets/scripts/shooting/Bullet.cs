using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Vector3 direction = new Vector3(-1, 0, 0);

    public PlayerMovement playerMovement;

    private void Start()
    {
        // Find the PlayerMovement component in the scene
        playerMovement = FindObjectOfType<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement component not found in the scene.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerMovement != null)
        {
            Debug.Log("Last Direction: " + playerMovement.LastDirection);

            if (playerMovement.LastDirection == 1)
            {
                direction = new Vector3(1, 0, 0);
                Debug.Log("Direction: " + direction);
            }
            else if (playerMovement.LastDirection == -1)
            {
                direction = new Vector3(-1, 0, 0);
                Debug.Log("Direction: " + direction);
            }

            // Move the GameObject forward using Vector3
            this.transform.position += (direction * speed * Time.deltaTime);
        }
    }
}
