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
	private int score = 0;
	private int baseScore = 0;
	public Text playerScore;
	public Text finalScore;
	public Text playerGold;
	


	public int life;//���Ѫ��
	public Text hp;//Ѫ����ʾ

	public GameObject endPanel;


	private bool isGameOver = false;

	void Start()
	{
		if (File.Exists(Application.dataPath + "/StreamingFile" + "/byBin.txt"))
		{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream fileStream = File.Open(Application.dataPath + "/StreamingFile" + "/byBin.txt",FileMode.Open);
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
			FileStream fileStream = File.Create(Application.dataPath + "/StreamingFile" + "/byBin.txt");
			bf.Serialize(fileStream, saveData);
			fileStream.Close();
			
			endPanel.SetActive(true);
			finalScore.text = playerScore.text;
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


