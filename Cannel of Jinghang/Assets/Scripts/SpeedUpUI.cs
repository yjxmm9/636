using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("SpeedUpUI");//�ҵ�SpeedUpUI
        canvas.transform.Find("Panel").gameObject.SetActive(false);//�����ʼ������Ϊ����ʾ
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject canvas = GameObject.Find("SpeedUpUI");//�ҵ�SpeedUpUI
        canvas.transform.Find("Panel").gameObject.SetActive(true);//��������Ϊ��ʾ
        SpeedUped();

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject canvas = GameObject.Find("SpeedUpUI");//�ҵ�SpeedUpUI
        canvas.transform.Find("Panel").gameObject.SetActive(false);//��������
    }

    private void SpeedUped ()
    {
        GameObject testBoat = GameObject.Find("TestBoat");
        GameObject player = GameObject.Find("JunkoChan");
        testBoat.GetComponent<TestBoatController>().speed += 4;;
        player.GetComponent<PlayerController>().speed += 4;
    }
}
