using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraMove : MonoBehaviour
{

    private int speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
    }
}
