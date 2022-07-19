using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{

    public GameObject CountDownOne;
    public GameObject CountDownTwo;
    public GameObject CountDownThree;
    public GameObject TestBoat;
    public GameObject Player;
    private float speed;
    public bool iscounting;

    void Start()
    {
        
        CountDownOne.SetActive(false);
        CountDownTwo.SetActive(false);
        CountDownThree.SetActive(false);//��ʼ������ʱ����Ϊfalse
        
        speed = TestBoat.GetComponent<TestBoatController>().speed;//��ȡ���ڵĴ��ٶ�
        TestBoat.GetComponent<TestBoatController>().speed = 0;//��������Ϊ=0�����ﵽ��ͣ��timescale��Ϊ0
        Player.GetComponent<PlayerController>().speed = 0;//��Player�ٶ���Ϊ0

        StartCoroutine(CountDownIE()) ;//��ʼ����ʱЭ��
    }

    public IEnumerator CountDownIE()
    {
        iscounting = true;
        CountDownThree.SetActive(true);
        Time.timeScale = 1;
        yield return new WaitForSeconds(1);
        CountDownThree.SetActive(false);
        CountDownTwo.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDownTwo.SetActive(false);
        CountDownOne.SetActive(true);

        yield return new WaitForSeconds(1);
        CountDownOne.SetActive(false);
        
        TestBoat.GetComponent<TestBoatController>().speed = speed;
        Player.GetComponent<PlayerController>().speed = speed;//��λ�ٶȣ���ʼ��Ϸ
        iscounting = false;
    }

}
