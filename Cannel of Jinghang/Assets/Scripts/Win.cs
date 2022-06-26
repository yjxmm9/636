using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel").gameObject.SetActive(true);
        StartCoroutine(Re(1));
    }

    IEnumerator Re(int Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        Rewind();
        GameObject canvas = GameObject.Find("Canvas");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
        yield break;
    }

    private void Rewind()
    {
        GameObject testBoat = GameObject.Find("TestBoat");
        testBoat.transform.position = new Vector3(testBoat.transform.position.x, 0, 0);
        testBoat.GetComponent<TestBoatController>().speed += 1;
    }
    


}
