using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Forever").Length > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }
}
