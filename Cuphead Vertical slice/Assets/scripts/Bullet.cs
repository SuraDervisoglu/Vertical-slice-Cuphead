using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10f;
    private float damage = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.X))
        {
            Instantiate(gameObject, transform.position, transform.rotation);
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
