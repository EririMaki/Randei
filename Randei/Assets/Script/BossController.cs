using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

	public float EnemyMinSpeed;
	public float EnemyMaxSpeed;
	//开始第一次等待闪避的最小最大时间
	public float waitMin;
	public float waitMax;
	//闪避最短最长时间
	public float EnemyMinTime;
	public float EnemyMaxTime;
	//随机闪避目标速度
	private float EnemyTargetSpeed;
	//敌人加速度
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
                //敌人飞船在右边，往左闪避
                EnemyTargetSpeed = -EnemyTargetSpeed;
            }
            yield return new WaitForSeconds(Random.Range(EnemyMinTime, EnemyMaxTime));
            EnemyTargetSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        //通过加速度产生的渐变速度
        float EnemyVal = Mathf.MoveTowards(rbd.velocity.x, EnemyTargetSpeed, Time.deltaTime * accelerSpeed);
        rbd.velocity = new Vector3(EnemyTargetSpeed, 0, rbd.velocity.z);

        //产生偏转
        rbd.rotation = Quaternion.Euler(0, 0, rbd.velocity.x * (-1) * tilt);


    }
}
