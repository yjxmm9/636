using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestBoatController : MonoBehaviour
{
    public float speed;//前进速度
    
    public float turnspeed;//转向速度

    //how long to keep moving up or down until switching direction
    public float verticalTime = 1f;
    //how fast to move vertically
    public float verticalSpeed = 5f;
    //Transform myTrans;

    //控制玩家是否可以吸取周围的金币
    private bool isMagnet = false;
    private float magnetTimer=10f;


    public bool isShield = false;
    private float shieldTimer = 10f;

    public float changeSpeed;
    public GameObject player;
    private float speedTimer=10f;
    private bool isSpeeding;

    public AudioSource audiosource;
    public AudioClip DefeatSound;
    public GameObject ButtonAnswer;
    public AudioClip collectSound;

    public Text DieScore;




    private void Awake()
    {
        if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedboat)
        {
            transform.position = GameObject.Find("Forever").GetComponent<Forever>().newpositionboat;
            GameObject.Find("Forever").GetComponent<Forever>().isrevivedboat = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //myTrans = this.transform;
        //StartCoroutine(Rise());
        //Time.timeScale = 1;
        GameObject canvas = GameObject.Find("DieUI");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
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
        Magnet();

        if (isMagnet)
        {
            magnetTimer -= Time.deltaTime;
            if (magnetTimer<=0)
            {
                isMagnet = false;
                magnetTimer = 10f;
            }
        }

        if (isShield)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer<=0)
            {
                isShield = false;
                shieldTimer = 10f;
            }
        }

        if (isSpeeding)
        {
            speedTimer -= Time.deltaTime;
            if (speedTimer <= 0)
            {
                isSpeeding = false;
                speed -= changeSpeed;
                player.GetComponent<PlayerController>().speed -= changeSpeed;
                speedTimer = 10f;
            }
        }

    }

    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.fixedDeltaTime, 0, speed * Time.fixedDeltaTime);//向前移动
        Rotating(horizontal);//转向方法

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

    public void OnTriggerEnter(Collider other)
    {
        
        if ("Coin" == other.gameObject.tag)
        {
            UIManager.Instance.UpdateUI(100);
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("Magnet"))
        {
            //设置玩家可以吸取周围的金币
            isMagnet = true;
            //销毁吸铁石
            Destroy(other.gameObject);
        }
        if (other.tag.Equals("Shield"))
        {
            isShield = true;
            Destroy(other.gameObject);
        }

        if (other.tag.Equals("RiverBank"))
        {
            Time.timeScale = 0;
            GameObject canvas = GameObject.Find("DieUI");
            canvas.transform.Find("Panel").gameObject.SetActive(true);
            DieScore.text = "得分:" + UIManager.Instance.score;
            if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton)
            {
                ButtonAnswer.SetActive(false);
                GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = false;
            }
            PlaySound(DefeatSound);
        }

        if (other.tag.Equals("Speed"))
        {
            isSpeeding = true;
            speed += changeSpeed;
            player.GetComponent<PlayerController>().speed+=changeSpeed;
            Destroy(other.gameObject);
        }

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
                DieScore.text = "得分:" + UIManager.Instance.score;
                if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton)
                {
                    ButtonAnswer.SetActive(false);
                    GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = false;
                }
                PlaySound(DefeatSound);
            }
            
        }

        //if (other.tag == "Collection")
        //{
        //    WinUI.collectionCount += 1;
        //    UIManager.Instance.UpdateUI(100);
        //    Destroy(other.gameObject);//在收集到之后摧毁该物体
        //    PlaySound(collectSound);
        //}


    }

    private void Magnet()
    {
        if (isMagnet)
        {
            //检测以玩家为球心半径是5的范围内的所有的带有碰撞器的游戏对象
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, 5);
            foreach (var item in colliders)
            {
                //如果是金币
                if (item.tag.Equals("Coin"))
                {
                    //让金币的开始移动
                    item.GetComponent<Coin>().isCanMove = true;
                }
            }

        }

        
    }


    public void PlaySound(AudioClip audioClip)
    {
        audiosource.PlayOneShot(audioClip, 0.25f);
    }


    //IEnumerator Rise()
    //{
    //    float t = verticalTime;
    //    while (t > 0f)
    //    {
    //        myTrans.Translate(myTrans.up * verticalSpeed * Time.deltaTime);
    //        t -= Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }
    //    StartCoroutine(Fall());
    //}

    //IEnumerator Fall()
    //{
    //    float t = verticalTime;
    //    while (t > 0f)
    //    {
    //        myTrans.Translate(-myTrans.up * verticalSpeed * Time.deltaTime);
    //        t -= Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }
    //    StartCoroutine(Rise());

    //}
}
