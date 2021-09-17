using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffController : MonoBehaviour
{
	public GameObject[] buffs;
	public Vector3 spawnValues;

	public int buffCount; //一批敌人的数量
	public float buffWait; //一批中，单个敌人生成的间隔时间
	public float startBuffWait; //开始的暂停时间
	public float BuffwaveWait; //两批敌人之间的间隔时间

	void Start()
	{

		StartCoroutine(SpawnBuffWaves());

	}

	IEnumerator SpawnBuffWaves()
	{
		yield return new WaitForSeconds(startBuffWait);
		while (true)
		{
			for (int i = 0; i < buffCount; i++)
			{
				int index = Random.Range(0, buffs.Length);
				GameObject go = buffs[index];
				Vector3 pos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion rot = Quaternion.identity;
				Instantiate(go, pos, rot);
				yield return new WaitForSeconds(buffWait);
			}

			yield return new WaitForSeconds(BuffwaveWait);
		}
	}
}


