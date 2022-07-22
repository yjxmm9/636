using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    public float speed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime, 0, 0);//œÚ«∞“∆∂Ø
    }
}
