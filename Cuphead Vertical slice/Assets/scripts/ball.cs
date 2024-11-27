using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    Vector3 velocity;
    Vector3 direction = new Vector3(1, 1, 0);
    float speed = 3;

    Vector2 min, max;


    // Start is called before the first frame update
    void Start()
    {
        min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        direction = direction.normalized;
        velocity = speed * direction;

        this.transform.position += velocity * Time.deltaTime;

        if (this.transform.position.x < min.x || this.transform.position.x > max.x)
        {
            direction.x *= -1;
        }
        else if (this.transform.position.y < min.y || this.transform.position.y > max.y)
        {
            direction.y *= -1;
        }
    }
}
