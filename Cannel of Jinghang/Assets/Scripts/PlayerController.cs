using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public float turnspeed;
    private Rigidbody rb;
    private Vector3 jump;
    public float jumpForce = 2f;

    //public float jumpTimer;
    private bool isjumping = false;
    public int gravity = -35;
    private float Height;
    private bool iscrouching = false;

    Vector3  collStandOffset,  collCrouchOffset;
    float collStandSize, collCrouchSize,collStandRadius,collCrouchRadius;
    CapsuleCollider coll;
    

    public bool isShield;//护盾
    public GameObject testBoat;//传入testBoat物体
    public GameObject ButtonAnswer;
    public GameObject CountUI;

    private Animator pa;

    public AudioSource audioSource;
    public AudioSource boatAudioSource;
    public AudioClip JumpSound;
    public AudioClip BoatSound;
    public AudioClip DefeatSound;
    public AudioClip collectSound;

    public Text DieScore;

    

    private void Awake()
    {
        if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedplayer)
        {
            transform.position = GameObject.Find("Forever").GetComponent<Forever>().newpositionplayer;
            UIManager.Instance.score= GameObject.Find("Forever").GetComponent<Forever>().lastScore;
            //Debug.Log(GameObject.Find("Forever").GetComponent<Forever>().collectNum);
            GameObject.Find("Forever").GetComponent<Forever>().isrevivedplayer = false;
        }
    }


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

        boatAudioSource.clip = BoatSound;
        boatAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(WinUI.collectionCount);
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

        if (Input.GetKeyDown(KeyCode.Space)&&CheckGrounded()&&!iscrouching)
        {
            pa.SetBool("Jump", true);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isjumping = true;
            PlaySound(JumpSound);
            //jumpTimer = 0;
            
        }
        if (!CheckGrounded() && transform.position.y - Height < 0)
        {//When Junkochan is falling, tansit animation state from "Ascending" to "Falling"
            pa.SetBool("Fall", true);//Set Junkochan's "Run" parameter in Animator component
        }
        else
        {
            pa.SetBool("Fall", false);
            isjumping = false;
        }
        Height = transform.position.y;

        isShield = testBoat.GetComponent<TestBoatController>().isShield;

        Crouch();

        if (Time.timeScale==0)
        {
            boatAudioSource.Stop();
            PlayerPrefs.SetInt("lasts", UIManager.Instance.score);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag.Equals("Barrier"))
        {
            
                Time.timeScale = 0;
                GameObject canvas = GameObject.Find("DieUI");
                canvas.transform.Find("Panel").gameObject.SetActive(true);
            DieScore.text ="得分:"+ UIManager.Instance.score;
            if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton)
            {
                ButtonAnswer.SetActive(false);
                GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = false;
            }
            //Debug.Log(UIManager.Instance.revivetime);
            //if (UIManager.Instance.revivetime != 0)
            //{
            //    ButtonAnswer.SetActive(false);
            //}
            PlaySound(DefeatSound);
            

        }
        if (other.tag == "Collection1")
        {
            WinUI.collectionCount += 1;
            UIManager.Instance.UpdateUI(500);
            //Debug.Log(WinUI.collectionCount);
            Destroy(other.gameObject);//在收集到之后摧毁该物体
            PlaySound(collectSound);
            PlayerPrefs.SetInt("haveCollect1_1", 1);
            
            
        }
        if (other.tag == "Collection2")
        {
            WinUI.collectionCount += 1;
            UIManager.Instance.UpdateUI(500);
            //Debug.Log(WinUI.collectionCount);
            Destroy(other.gameObject);//在收集到之后摧毁该物体
            PlaySound(collectSound);
            PlayerPrefs.SetInt("haveCollect1_2", 1);
        }
        if (other.tag == "Collection3")
        {
            WinUI.collectionCount += 1;
            UIManager.Instance.UpdateUI(500);
            //Debug.Log(WinUI.collectionCount);
            Destroy(other.gameObject);//在收集到之后摧毁该物体
            PlaySound(collectSound);
            PlayerPrefs.SetInt("haveCollect1_3", 1);
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
        if (Input.GetKeyDown(KeyCode.C)&&CheckGrounded()&&!isjumping)
        {
            pa.SetBool("Crouch", true);
            coll.height = collCrouchSize;
            coll.center = collCrouchOffset;
            iscrouching = true;
            //coll.radius = collCrouchRadius;
            
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y/2, transform.localScale.z);
        }
        else if(Input.GetKeyUp(KeyCode.C) && CheckGrounded()&&!isjumping)
        {
            pa.SetBool("Crouch", false);
            coll.center = collStandOffset;
            coll.height = collStandSize;
            iscrouching = false;
            //coll.radius = collStandRadius;
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*2, transform.localScale.z);

        }
    }

    private void Score()
    {
        if (!CountUI.GetComponent<CountDown>().iscounting)
        {
            UIManager.Instance.UpdateUI(1);
        }
        
    }

    bool CheckGrounded()
    {//Judge whether Junkochan is on the ground or not
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.05f, Vector3.down * 0.15f);//Shoot ray at 0.05f upper from Junkochan's feet position to the ground with its length of 0.1f
        return Physics.Raycast(ray, 0.15f);//If the ray hit the ground, return true
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip, 0.25f);
    }

}
