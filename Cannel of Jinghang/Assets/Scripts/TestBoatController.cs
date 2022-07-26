using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestBoatController : MonoBehaviour
{
    public float speed;//ǰ���ٶ�
    
    public float turnspeed;//ת���ٶ�

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
        if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedboat)//��ȡ����ǰ����
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("RiverBank"))//ײ���Ӱ�
        {
            Time.timeScale = 0;
            GameObject canvas = GameObject.Find("DieUI");
            canvas.transform.Find("Panel").gameObject.SetActive(true);
            DieScore.text = "�÷�:" + UIManager.Instance.score;
            if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton)
            {
                ButtonAnswer.SetActive(false);
                GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = false;
            }
            PlaySound(DefeatSound);
        }

        if (other.tag.Equals("Barrier"))//ײ���ϰ�
        {
            Time.timeScale = 0;
            GameObject canvas = GameObject.Find("DieUI");
            canvas.transform.Find("Panel").gameObject.SetActive(true);
            DieScore.text = "�÷�:" + UIManager.Instance.score;
            if (GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton)
            {
                ButtonAnswer.SetActive(false);
                GameObject.Find("Forever").GetComponent<Forever>().isrevivedbutton = false;
            }
             PlaySound(DefeatSound);
            Debug.Log(other.name);
        }
    }
    public void PlaySound(AudioClip audioClip)//������Ƶ
    {
        audiosource.PlayOneShot(audioClip, 0.25f);
    }

}
