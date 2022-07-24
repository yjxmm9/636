using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    public float speed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-speed * Time.fixedDeltaTime, 0, 0);
        
    }

    private void Update()
    {
        if (transform.position.x <= -100)
        {
            speed = 0f;
        }
    }
}
