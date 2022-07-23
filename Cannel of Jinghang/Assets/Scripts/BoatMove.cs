using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    public float speed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, -speed * Time.fixedDeltaTime);//œÚ«∞“∆∂Ø
        
    }

    private void Update()
    {
        if (transform.position.x <= -3.7)
        {
            speed = 0f;
        }
    }
}
