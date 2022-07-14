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

    //public float jumpTimer;
    public bool isjumping = false;
    public int gravity = -35;
    private float Height;

    Vector3  collStandOffset,  collCrouchOffset;
    float collStandSize, collCrouchSize,collStandRadius,collCrouchRadius;
    CapsuleCollider coll;
    

    private bool isShield;//护盾
    public GameObject testBoat;//传入testBoat物体

    private Animator pa;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pa = this.GetComponent<Animator>();
        jump = new Vector3(0.0f, 1f, 0.0f);

        coll = GetComponent<CapsuleCollider>();
        collStandSize = coll.height;    //获取一开始的碰撞体大小
        collStandOffset = coll.center;    //获取一开始的碰撞体位置
        collStandRadius = coll.radius;
        collCrouchSize = coll.height/1.3f;  //获取下蹲时候的碰撞体大小
        collCrouchOffset = new Vector3(coll.center.x, coll.center.y/1.3f, coll.center.z);    //获取下蹲时候的碰撞体位置
        collCrouchRadius = coll.radius / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        //jumpTimer += Time.deltaTime;
        if (CheckGrounded())
        {//When Junkochan is on the ground
            pa.SetBool("Grounded", true);//Set Junkochan's "Grounded" parameter in Animator component
            pa.SetBool("Jump", false);
        }
        else
        {
            pa.SetBool("Grounded", false);
        }

        Physics.gravity = new Vector3(0, gravity, 0);  // gravity= -35 其他的默认

        if (Input.GetKeyDown(KeyCode.Space)&&CheckGrounded())
        {
            pa.SetBool("Jump", true);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            //jumpTimer = 0;
            
        }
        if (!CheckGrounded() && transform.position.y - Height < 0)
        {//When Junkochan is falling, tansit animation state from "Ascending" to "Falling"
            pa.SetBool("Fall", true);//Set Junkochan's "Run" parameter in Animator component
        }
        else
        {
            pa.SetBool("Fall", false);
        }
        Height = transform.position.y;

        isShield = testBoat.GetComponent<TestBoatController>().isShield;

        Crouch();
    }


    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag.Equals("Barrier"))
        {
            if (isShield)
            {
                Destroy(other.gameObject);
                return;
            }
            else
            {
                Time.timeScale = 0;
                GameObject canvas = GameObject.Find("DieUI");
                canvas.transform.Find("Panel").gameObject.SetActive(true);
            }

        }
    }


    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.fixedDeltaTime, 0, speed * Time.fixedDeltaTime);//向前移动
        Rotating(horizontal);//转向方法
        Score();


    }

    private void Rotating(float hor)//转向方法
    {
        //获取方向
        Vector3 dir = new Vector3(hor, 0, 1);
        //将方向转换为四元数
        Quaternion quaDir = Quaternion.LookRotation(dir, Vector3.up);
        //缓慢转动到目标点
        transform.rotation = Quaternion.Lerp(transform.rotation, quaDir, Time.fixedDeltaTime * turnspeed);
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C)&&CheckGrounded())
        {
            pa.SetBool("Crouch", true);
            coll.height = collCrouchSize;
            coll.center = collCrouchOffset;
            //coll.radius = collCrouchRadius;
            
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y/2, transform.localScale.z);
        }
        else if(Input.GetKeyUp(KeyCode.C) && CheckGrounded())
        {
            pa.SetBool("Crouch", false);
            coll.center = collStandOffset;
            coll.height = collStandSize;
            //coll.radius = collStandRadius;
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*2, transform.localScale.z);

        }
    }

    private void Score()
    {
        UIManager.Instance.UpdateUI(1);
    }

    bool CheckGrounded()
    {//Judge whether Junkochan is on the ground or not
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.05f, Vector3.down * 0.15f);//Shoot ray at 0.05f upper from Junkochan's feet position to the ground with its length of 0.1f
        return Physics.Raycast(ray, 0.15f);//If the ray hit the ground, return true
    }

}
