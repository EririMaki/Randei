using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public GameObject[] enemys;
	public Vector3 spawnValues;

	public int hazardCount; //一批敌人的数量
	public float spawnWait; //一批中，单个敌人生成的间隔时间
	public float startWait; //开始的暂停时间
	public float waveWait; //两批敌人之间的间隔时间
	private int score = 0;
	public Text playerScore;
	public Text finalScore;

	public int life;//玩家血量
	public Text hp;//血量显示

	public GameObject endPanel;


	private bool isGameOver = false;

	void Start()
	{

		StartCoroutine(SpawnWaves());
		life = 3;
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

	public void getHP(int damage)
	{
		life -= damage;
		Debug.Log("life: " + life);
		hp.text = "Life: " + life.ToString();
	}

	public void GameOver()
	{
		if (life == 0)
		{
			
			endPanel.SetActive(true);
			
			isGameOver = true;
			
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void ExitGame()
	{
	#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
	#else
		Application.Quit();
	#endif
	}

}


