using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject[] enemys;
	public Vector3 spawnValues;

	public int hazardCount; //һ�����˵�����
	public float spawnWait; //һ���У������������ɵļ��ʱ��
	public float startWait; //��ʼ����ͣʱ��
	public float waveWait; //��������֮��ļ��ʱ��
	private int score = 0;
	public Text playerScore;
	public GameObject endPanel;

	private bool isGameOver = false;

	void Start()
	{

		StartCoroutine(SpawnWaves());

	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				int index = Random.Range(0, enemys.Length);
				GameObject go = enemys[index];
				Vector3 pos = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion rot = Quaternion.identity;
				Instantiate(go, pos, rot);
				yield return new WaitForSeconds(spawnWait);
			}
			if (isGameOver == true)
			{
				break;
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	public void AddScore(int value)
	{
		score += value;
		Debug.Log("score: " + score);
		playerScore.text = "Score: " + score.ToString();
	}

	public void GameOver()
	{
		endPanel.SetActive(true);
		isGameOver = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


}

