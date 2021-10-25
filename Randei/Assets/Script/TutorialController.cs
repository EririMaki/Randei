using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TutorialController : MonoBehaviour
{
    public GameObject[] enemys;
	public Vector3 spawnValues;

	public int hazardCount; //һ�����˵�����
	public float spawnWait; //һ���У������������ɵļ��ʱ��
	public float startWait; //��ʼ����ͣʱ��
	public float waveWait; //��������֮��ļ��ʱ��
	public int score = 0;//��Ϸ����
	public int HScore = 0;//��߷���
	public int life;//���Ѫ��
	public Text hp;//Ѫ����ʾ

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
		if (Input.GetKeyDown(KeyCode.W))

        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonW").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.blue;

		Debug.Log(compo);
        }

		if (Input.GetKeyUp(KeyCode.W))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonW").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.white;
        }

		if (Input.GetKeyDown(KeyCode.A))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonA").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.blue;
        }

		if (Input.GetKeyUp(KeyCode.A))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonA").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.white;
        }

		if (Input.GetKeyDown(KeyCode.S))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonS").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.blue;
        }

		if (Input.GetKeyUp(KeyCode.S))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonS").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.white;
        }

		if (Input.GetKeyDown(KeyCode.D))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonD").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.blue;
        }

		if (Input.GetKeyUp(KeyCode.D))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonD").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.white;
        }

		if (Input.GetKeyDown(KeyCode.J))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonJ").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.blue;
        }

		if (Input.GetKeyUp(KeyCode.J))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonJ").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.white;
        }

		if (Input.GetKeyDown(KeyCode.Space))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonSpace").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.blue;
        }

		if (Input.GetKeyUp(KeyCode.Space))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonSpace").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.white;
        }

		if (Input.GetKeyDown(KeyCode.RightControl))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonCtrl").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.blue;
        }

		if (Input.GetKeyUp(KeyCode.RightControl))
        {
           UnityEngine.UI.Button compo = GameObject.Find("ButtonCtrl").GetComponent<UnityEngine.UI.Button>();
		   compo.GetComponent<Image>().color = Color.white;
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
			RankingSortSave(score, save);//enter parameter for calculation
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fileStream = File.Create(Application.dataPath + "/Savedata" + "/byBin.txt" );
			bf.Serialize(fileStream, save);
			fileStream.Close();

			endPanel.SetActive(true);
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

	public void ExitGame()
	{
	#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
	#else
		Application.Quit();
	#endif
	}
}
