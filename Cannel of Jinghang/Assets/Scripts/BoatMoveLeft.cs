using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMoveLeft : MonoBehaviour
{
    public float speed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, -speed * Time.fixedDeltaTime);//ÏòÇ°ÒÆ¶¯

    }

    private void Update()
    {
        if (transform.position.x >= 4.5)
        {
            speed = 0f;
        }
    }
}
