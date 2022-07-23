using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcboat : MonoBehaviour
{
    public int speed;
    private Vector3 Movex=Vector3.zero;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate((Vector3.forward+Movex) * speed * Time.fixedDeltaTime,Space.World);//œÚ«∞“∆∂Ø
    }

    public void ChangePosition()
    {
        Movex = Vector3.right;
    }
}
