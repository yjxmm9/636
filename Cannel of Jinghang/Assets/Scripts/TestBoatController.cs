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

    public float changeSpeed;
    public GameObject player;
    

    public AudioSource audiosource;
    public AudioClip DefeatSound;
    public GameObject ButtonAnswer;
    public AudioClip collectSound;

    public Text DieScore;

    private void Awake()
    {
        if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedboat)//读取复活前参数
        {
            transform.position = GameObject.Find("Forever").GetComponent<Forever>().newpositionboat;
            GameObject.Find("Forever").GetComponent<Forever>().isrevivedboat = false;
        }
    }

    
    void Start()
    {
        
        GameObject canvas = GameObject.Find("DieUI");
        canvas.transform.Find("Panel").gameObject.SetActive(false);
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
        if (other.tag.Equals("RiverBank"))//撞到河岸
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

        if (other.tag.Equals("Barrier"))//撞到障碍
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
            Debug.Log(other.name);
        }
    }
    public void PlaySound(AudioClip audioClip)//播放音频
    {
        audiosource.PlayOneShot(audioClip, 0.25f);
    }

}
