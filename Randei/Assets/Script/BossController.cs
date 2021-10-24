using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

	public float EnemyMinSpeed;
	public float EnemyMaxSpeed;
	//��ʼ��һ�εȴ����ܵ���С���ʱ��
	public float waitMin;
	public float waitMax;
	//��������ʱ��
	public float EnemyMinTime;
	public float EnemyMaxTime;
	//�������Ŀ���ٶ�
	private float EnemyTargetSpeed;
	//���˼��ٶ�
	public float accelerSpeed;

	private Rigidbody rbd;
	public float tilt;

	void Start()
	{

		rbd = GetComponent<Rigidbody>();
		StartCoroutine(CalcEnemySpeed());

	}
    IEnumerator CalcEnemySpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(waitMin, waitMax));
            EnemyTargetSpeed = Random.Range(EnemyMinSpeed, EnemyMaxSpeed);
            if (transform.position.x > 0)
            {
                //���˷ɴ����ұߣ���������
                EnemyTargetSpeed = -EnemyTargetSpeed;
            }
            yield return new WaitForSeconds(Random.Range(EnemyMinTime, EnemyMaxTime));
            EnemyTargetSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        //ͨ�����ٶȲ����Ľ����ٶ�
        float EnemyVal = Mathf.MoveTowards(rbd.velocity.x, EnemyTargetSpeed, Time.deltaTime * accelerSpeed);
        rbd.velocity = new Vector3(EnemyTargetSpeed, 0, rbd.velocity.z);

        //����ƫת
        rbd.rotation = Quaternion.Euler(0, 0, rbd.velocity.x * (-1) * tilt);


    }
}
