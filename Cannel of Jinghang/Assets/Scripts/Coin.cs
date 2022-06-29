using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //����ƶ��ĵ�Ŀ��
    GameObject target;
    //����Ƿ�����ƶ�
    public bool isCanMove = false;
    //����ƶ����ٶ�
    public float speed = 50;
    // Use this for initialization
    void Start()
    {
        //��ȡ���
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isCanMove)
        {
            //���������ƶ����ٶ�
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //���������������������
        if (other.tag.Equals("Player"))
        {
            //���������Һ�ͻ����ٽ��
            Destroy(gameObject);
        }
    }
}
