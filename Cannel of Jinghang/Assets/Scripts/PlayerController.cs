using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public float turnspeed;
    private Rigidbody rb;
    private Vector3 jump;
    public float jumpForce = 2f;

    public float jumpTimer;
    private bool isjumping;

    Vector3 collStandSize, collStandOffset, collCrouchSize, collCrouchOffset;
    BoxCollider coll;
    bool isCrouch;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1f, 0.0f);

        coll = GetComponent<BoxCollider>();
        collStandSize = coll.size;    //��ȡһ��ʼ����ײ���С
        collStandOffset = coll.center;    //��ȡһ��ʼ����ײ��λ��
        collCrouchSize = new Vector3(coll.size.x, coll.size.y / 2, coll.size.z);  //��ȡ�¶�ʱ�����ײ���С
        collCrouchOffset = new Vector3(coll.center.x, -0.25f, coll.center.z);    //��ȡ�¶�ʱ�����ײ��λ��
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isjumping)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer>2)
            {
                isjumping = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space)&&!isjumping&&!isCrouch)
        {
            GetComponent<Animator>().SetBool("isFalling", true);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            jumpTimer = 0;
            isjumping = true;
        }

        Crouch();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            GetComponent<Animator>().SetBool("isFalling", false);
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

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C)&&!isjumping)
        {
            isCrouch = true;
            coll.size = collCrouchSize;
            coll.center = collCrouchOffset;
            GetComponent<Animator>().SetBool("isCrouching", true);
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y/2, transform.localScale.z);
        }
        else if(Input.GetKeyUp(KeyCode.C) && !isjumping)
        {
            isCrouch = false;
            coll.center = collStandOffset;
            coll.size = collStandSize;
            GetComponent<Animator>().SetBool("isCrouching", false);
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*2, transform.localScale.z);

        }
    }

    

}