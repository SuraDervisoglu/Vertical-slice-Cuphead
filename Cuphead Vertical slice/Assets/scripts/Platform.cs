using System.Collections;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of movement
    [SerializeField] private float timeA = 1f; // Minimum time to move up
    [SerializeField] private float timeB = 3f; // Maximum time to move up

    private bool isMoving = true;

    void Start()
    {
        // Get a random time between timeA and timeB
        float moveTime = Random.Range(timeA, timeB);
        StartCoroutine(MoveUpForTime(moveTime));
    }

    void Update()
    {
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
}
