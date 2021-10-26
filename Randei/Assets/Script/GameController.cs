using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*
 * Warning!!!!
 * If there is an error says that the int Array from GameSaveData is NULL (which is the data from binary formatter)
 * developers have to delete the save file from Asset --> Savedata --> byBin.txt
 * 
 * The reason seems like if u use different machine, and was working with different save file e.g. one file only contains int health, another contains int health and some other things
 * Then the BinaryFormatter will ignore the changes. But if u made changes in the same PC then there won't be problems
 * 
 * We was struggled from this strenge issue for hours!!!!!!!!
 * WDNMD就无语！
 * */
public class GameController : MonoBehaviour
{
	public GameObject[] enemys;
	public Vector3 spawnValues;

	public int hazardCount; //一批敌人的数量
	public float spawnWait; //一批中，单个敌人生成的间隔时间
	public float startWait; //开始的暂停时间
	public float waveWait; //两批敌人之间的间隔时间
	public int score = 0;//游戏分数
	public Text playerScore;//记录分数的TEXT
	public Text finalScore;//最后得分的TEXT
	public int HScore = 0;//最高分数
	public int life;//玩家血量
	public Text hp;//血量显示
	public Text playerGold;
	private int baseGold = 0;
	private int baseHealth = 0;

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

	public GameSaveData save = new GameSaveData();
	int[] currentArray = new int[5];

	private void Awake()
    {
		if (File.Exists(Application.dataPath + "/Savedata" + "/byBin.txt"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fileStream = File.Open(Application.dataPath + "/Savedata" + "/byBin.txt", FileMode.Open);
			save = (GameSaveData)bf.Deserialize(fileStream);
			fileStream.Close();
			baseGold = save.gold;
			baseHealth = save.health;
			playerGold.text = "Gold: " + baseGold.ToString();
		}
		else
		{
			playerGold.text = "Gold: " + baseGold.ToString();
		}
        
		
		life = 3 + baseHealth;
		hp.text = "Life: " + life.ToString();
	}
    void Start()
	{
		StartCoroutine(SpawnWaves());
		StartCoroutine(SpawnBossWaves());
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
		playerGold.text = "Gold: " + (baseGold + score).ToString();
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
			//GameSaveData saveData = new GameSaveData();
			save.gold = score + baseGold;			
			RankingSortSave(score, save);//enter parameter for calculation
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fileStream = File.Create(Application.dataPath + "/Savedata" + "/byBin.txt" );
			bf.Serialize(fileStream, save);
			fileStream.Close();

			endPanel.SetActive(true);
			finalScore.text = "Game Over!\n" + playerScore.text;
			isGameOver = true;
		}
       
    }


    //sorting the ranking before serialize it
    public void RankingSortSave(int currentScore, GameSaveData saveData)
    {
        //GameSaveData gameData = new GameSaveData();
        //Must clearify the System IO ports for using array sorting
        //but do not only using System, otherwise you cannot use Random because that Random is conflict and unclear.
        //can be solve in seetings by changing .net to .NET2.0. However, I donot recomment to do so
        //as we can clearify the System to the Array.Sort when we use it. --- Tai

        System.Array.Sort(saveData.ranking);//sorting the array
        System.Array.Reverse(saveData.ranking);//Reverse array for Descending order
                                           //Please do not use foreach in the Update(), it will cause many memory wastes.		

        foreach (var item in save.ranking)
        {
            if (item < currentScore)
            {
                int arrLength = saveData.ranking.Length;
                int index = System.Array.IndexOf(saveData.ranking, item);
				saveData.ranking[arrLength - 1] = item;
				saveData.ranking[index] = currentScore;
                System.Array.Sort(saveData.ranking);//sorting the array
                System.Array.Reverse(saveData.ranking);//Reverse array for Descending order
                break;
            }
        }
    }


    public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void DuoRestart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        Time.timeScale = 1f;
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


