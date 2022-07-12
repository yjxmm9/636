using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("SpeedUpUI");//找到SpeedUpUI
        canvas.transform.Find("Panel").gameObject.SetActive(false);//将其初始化设置为不显示
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject canvas = GameObject.Find("SpeedUpUI");//找到SpeedUpUI
        canvas.transform.Find("Panel").gameObject.SetActive(true);//将其设置为显示
        SpeedUped();

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject canvas = GameObject.Find("SpeedUpUI");//找到SpeedUpUI
        canvas.transform.Find("Panel").gameObject.SetActive(false);//将其隐藏
    }

    private void SpeedUped ()
    {
        GameObject testBoat = GameObject.Find("TestBoat");
        GameObject player = GameObject.Find("JunkoChan");
        testBoat.GetComponent<TestBoatController>().speed += 4;;
        player.GetComponent<PlayerController>().speed += 4;
    }
}
