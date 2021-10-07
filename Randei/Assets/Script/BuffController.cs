using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuffController : MonoBehaviour
{
	public GameObject[] buffs;
	public Vector3 spawnValues;

	public int buffCount; //the number of  buffs in one wave
	public float buffWait; //the gap time between 2 buffs
	public float startBuffWait; //start and end of the buff
	public float BuffwaveWait; //time between 2 waves of buff

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


