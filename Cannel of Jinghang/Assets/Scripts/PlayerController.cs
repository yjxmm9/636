using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    
    public float speed;
    public float turnspeed;
    private Rigidbody rb;
    private Vector3 jump;
    public float jumpForce = 2f;

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
        
    }


    void Start()
    {
        if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedplayer)//复活以后读取复活前的参数
        {
            transform.position = GameObject.Find("Forever").GetComponent<Forever>().newpositionplayer;
            UIManager.Instance.score = GameObject.Find("Forever").GetComponent<Forever>().lastScore;
            Debug.Log(UIManager.Instance.score);
            WinUI.collectionCount = GameObject.Find("Forever").GetComponent<Forever>().collectNum;
            GameObject.Find("Forever").GetComponent<Forever>().isrevivedplayer = false;
        }
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

    void Update()
    {
        if (CheckGrounded())//落地状态
        {//When Junkochan is on the ground
            pa.SetBool("Grounded", true);//Set Junkochan's "Grounded" parameter in Animator component
            pa.SetBool("Jump", false);
        }
        else
        {
            pa.SetBool("Grounded", false);
        }

        Physics.gravity = new Vector3(0, gravity, 0);  // gravity= -35 其他的默认

        if (Input.GetKeyDown(KeyCode.Space)&&CheckGrounded()&&!iscrouching)//跳跃
        {
            pa.SetBool("Jump", true);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isjumping = true;
            PlaySound(JumpSound);          
        }
        if (!CheckGrounded() && transform.position.y - Height < 0)//判断下落
        {//When Junkochan is falling, tansit animation state from "Ascending" to "Falling"
            pa.SetBool("Fall", true);//Set Junkochan's "Run" parameter in Animator component
        }
        else
        {
            pa.SetBool("Fall", false);
            isjumping = false;
        }
        Height = transform.position.y;

        Crouch();//下蹲

        if (Time.timeScale==0)//失败后结束船的bgm
        {
            boatAudioSource.Stop();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag.Equals("Barrier"))//撞到障碍
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
            PlaySound(DefeatSound);

        }
        //撞到收集品
        if (other.tag == "Collection1")
        {
            WinUI.collectionCount += 1;
            UIManager.Instance.UpdateUI(500);
            Destroy(other.gameObject);//在收集到之后摧毁该物体
            PlaySound(collectSound);
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                PlayerPrefs.SetInt("haveCollect1_1", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                PlayerPrefs.SetInt("haveCollect2_1", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                PlayerPrefs.SetInt("haveCollect3_1", 1);
            }
        }
        if (other.tag == "Collection2")
        {
            WinUI.collectionCount += 1;
            UIManager.Instance.UpdateUI(500);
            Destroy(other.gameObject);//在收集到之后摧毁该物体
            PlaySound(collectSound);
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                PlayerPrefs.SetInt("haveCollect1_2", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                PlayerPrefs.SetInt("haveCollect2_2", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                PlayerPrefs.SetInt("haveCollect3_2", 1);
            }
        }
        if (other.tag == "Collection3")
        {
            WinUI.collectionCount += 1;
            UIManager.Instance.UpdateUI(500);
            Destroy(other.gameObject);//在收集到之后摧毁该物体
            PlaySound(collectSound);
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                PlayerPrefs.SetInt("haveCollect1_3", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                PlayerPrefs.SetInt("haveCollect2_3", 1);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                PlayerPrefs.SetInt("haveCollect3_3", 1);
            }
        }

    }


    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.fixedDeltaTime, 0, speed * Time.fixedDeltaTime);//向前移动
        Rotating(horizontal);//转向方法
        Score();
        Debug.Log(UIManager.Instance.score);


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

    private void Crouch()//下蹲
    {
        if (Input.GetKeyDown(KeyCode.C)&&CheckGrounded()&&!isjumping)
        {
            pa.SetBool("Crouch", true);
            coll.height = collCrouchSize;
            coll.center = collCrouchOffset;
            iscrouching = true;
        }
        else if(Input.GetKeyUp(KeyCode.C) && CheckGrounded()&&!isjumping)
        {
            pa.SetBool("Crouch", false);
            coll.center = collStandOffset;
            coll.height = collStandSize;
            iscrouching = false;

        }
    }

    private void Score()//更新得分
    {
        if (!CountUI.GetComponent<CountDown>().iscounting)
        {
            UIManager.Instance.UpdateUI(1);
        }
        
    }

    bool CheckGrounded()//判断是否在地面的检测
    {//Judge whether Junkochan is on the ground or not
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.05f, Vector3.down * 0.15f);//Shoot ray at 0.05f upper from Junkochan's feet position to the ground with its length of 0.1f
        return Physics.Raycast(ray, 0.15f);//If the ray hit the ground, return true
    }

    public void PlaySound(AudioClip audioClip)//播放音频
    {
        audioSource.PlayOneShot(audioClip, 0.25f);
    }

}
