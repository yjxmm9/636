using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestBoatController : MonoBehaviour
{
    public float speed;//ǰ���ٶ�
    public float turnspeed;//ת���ٶ�

    //how long to keep moving up or down until switching direction
    public float verticalTime = 1f;
    //how fast to move vertically
    public float verticalSpeed = 5f;
    Transform myTrans;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        StartCoroutine(Rise());
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            return;
        }




    }

    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.fixedDeltaTime, 0, speed * Time.fixedDeltaTime);//��ǰ�ƶ�
        Rotating(horizontal);//ת�򷽷�

    }

    private void Rotating(float hor)//ת�򷽷�
    {
        //��ȡ����
        Vector3 dir = new Vector3(hor, 0, 1);
        //������ת��Ϊ��Ԫ��
        Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.up);
        //����ת����Ŀ���
        transform.rotation = Quaternion.Lerp(transform.rotation, quaDir, Time.fixedDeltaTime * turnspeed);
    }

    IEnumerator Rise()
    {
        float t = verticalTime;
        while (t > 0f)
        {
            myTrans.Translate(myTrans.up * verticalSpeed * Time.deltaTime);
            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        float t = verticalTime;
        while (t > 0f)
        {
            myTrans.Translate(-myTrans.up * verticalSpeed * Time.deltaTime);
            t -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(Rise());

    }
}
