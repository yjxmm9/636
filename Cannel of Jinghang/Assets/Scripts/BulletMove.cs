using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
	public float volocity = 10;
	public float angle = 30;

	float volocityY = 0;
	float volocityX = 0;
	float accumulateTime = 0;

	void Start()
	{
		volocityY = Mathf.Sin(Mathf.Deg2Rad * angle) * volocity;
		volocityX = Mathf.Cos(Mathf.Deg2Rad * angle) * volocity;
	}

	//Update is called once per frame
	void Update()
	{
		accumulateTime += Time.deltaTime;
		//ˮƽ���������˶�
		float x = volocityX * accumulateTime;

		//��ֱ�����������ٶ������˶�
		float y = volocityY * accumulateTime - 9.8f * 0.5f * Mathf.Pow(accumulateTime, 2);

		Vector3 pos = new Vector3(x, y, 0);
		if (pos.y >= 0)
		{
			//GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = pos;
			transform.position = pos;
		}
	}
}
