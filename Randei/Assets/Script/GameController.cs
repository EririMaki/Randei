using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour
{
	public GameObject[] enemys;
	public Vector3 spawnValues;

	public int hazardCount; //һ�����˵�����
	public float spawnWait; //һ���У������������ɵļ��ʱ��
	public float startWait; //��ʼ����ͣʱ��
	public float waveWait; //��������֮��ļ��ʱ��
	public int score = 0;//��Ϸ����
	public Text playerScore;//��¼������TEXT
	public Text finalScore;//���÷ֵ�TEXT
	public int HScore = 0;//��߷���
	public int life;//���Ѫ��
	public Text hp;//Ѫ����ʾ
	public Text playerGold;
	private int baseScore = 0;

	public GameObject endPanel;

	private bool isGameOver = false;

	public GameObject[] boss;
	public Vector3 spawnBossValues;
	public float bossCount;
	public float bossWait;
	public float startBossWait;
	public float BosswaveWait;
	public float difficulty;
	private float BossTimer = 20f;
	private float timer = 3f;
	private float enemy = 1f;

	void Start()
	{
		if (File.Exists(Application.dataPath + "/Savedata" + "/byBin.txt"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fileStream = File.Open(Application.dataPath + "/Savedata" + "/byBin.txt", FileMode.Open);
			GameSaveData save = (GameSaveData)bf.Deserialize(fileStream);
			fileStream.Close();
			baseScore = save.score;
			playerGold.text = "Gold: " + baseScore.ToString();
		}
		else
		{
			playerGold.text = "Gold: " + baseScore.ToString();
		}

		StartCoroutine(SpawnWaves());
		StartCoroutine(SpawnBossWaves());
		life = 3;
		difficulty = 0f;
	}

	private void Update()
	{
		BossTimer -= Time.deltaTime;
		timer -= Time.deltaTime;
		//Set timer to increase number of boss respawn
		if (BossTimer <= 0)
		{
			difficulty += 1;
			BossTimer = 16f;
			Debug.Log(difficulty);
		}
		//Set timer to increase number of enemies respawn
		if (BossTimer <= 0)
		{
			enemy += 1;
			timer = 3f;
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount + enemy; i++)
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

	IEnumerator SpawnBossWaves()
	{
		yield return new WaitForSeconds(startBossWait);
		while (true)
		{
			for (int i = 0; i < bossCount + difficulty; i++)
			{
				int index = Random.Range(0, boss.Length);
				GameObject go = boss[index];
				Vector3 pos = new Vector3(Random.Range(-spawnBossValues.x, spawnBossValues.x), spawnBossValues.y, spawnBossValues.z);
				Quaternion rot = Quaternion.identity;
				Instantiate(go, pos, rot);
				yield return new WaitForSeconds(bossWait);
			}

			yield return new WaitForSeconds(BosswaveWait);
		}
	}

	public void AddScore(int value)
	{
		//Do NOT touch the switch!!
		//this part is used to make sure the sychronization of score and final score!!
		switch (life){
			case 0: return;
					break;
		}
		score += value;
		Debug.Log("score: " + score);
		playerScore.text = "Score: " + score.ToString();
		playerGold.text = "Gold: " + (baseScore + score).ToString();
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
			GameSaveData saveData = new GameSaveData();
			saveData.score = score + baseScore;
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fileStream = File.Create(Application.dataPath + "/Savedata" + "/byBin.txt");
			bf.Serialize(fileStream, saveData);
			fileStream.Close();

			endPanel.SetActive(true);
			//endPanel.SetActive(true);
			finalScore.text = "Game Over!\n" + playerScore.text;
			isGameOver = true;
		}
        /*if (score > HScore)
        {
            HScore = score;
            //����߷����洢
            PlayerPrefs.SetInt("High", HScore);
        }*/
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


