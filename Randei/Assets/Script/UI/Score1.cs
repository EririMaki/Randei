using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Score1 : MonoBehaviour
{

    public List<Score> scoreList = new List<Score>();

    public StreamReader sr = new StreamReader (Application.dataPath + "/Assets/Resources/Ranking.txt");
    public string nextLine;

    //private string Name;
    private int numScore;
    private GameController _gameController;
    private float score2;
    private Transform Item;

    public void Awake()
    {
        _gameController = GetComponent<GameController>();
        Item = GameObject.Find("GameController/Rankinglist/Item").transform;

        while ((nextLine = sr.ReadLine()) != null)
        {
            scoreList.Add(JsonUtility.FromJson<Score>(nextLine));
        }
        sr.Close();//将所有存储的分数全部存到list中
    }
    public void s1()
    {
        score2 = _gameController.score;
        scoreList.Add(new Score(numScore));//分数名字直接调变量，不用给出细节
    }

    /// <summary>
    /// 当用户点击排行榜按钮时
    /// </summary>
    public void s2()
    {
        scoreList.Sort();
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Assets/Resources/Ranking.txt");
        if (scoreList.Count > 10) for (int i = 10; i <= scoreList.Count; i++) scoreList.RemoveAt(i - 1);
        for (int i = 0; i < scoreList.Count; i++)
        {
            sw.WriteLine(JsonUtility.ToJson(scoreList[i]));
            Debug.Log(scoreList[i].ToString());
        }
        sw.Close();


        for (int i = 0; i < scoreList.Count; i++)
        {
            GameObject item = Instantiate(Item.gameObject);
            item.gameObject.SetActive(true);
            item.transform.SetParent(Item.parent, false);
            item.transform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();
            //item.transform.Find("Name").GetComponent<Text>().text = scoreList[i].name;
            item.transform.Find("Score").GetComponent<Text>().text = scoreList[i].score.ToString();
        }

    }

    [System.Serializable]
    public class Score : System.IComparable<Score>
    {
        //public string name;
        public int score;
        public Score(int s) {score = s; }
        public int CompareTo(Score other)
        {
            if (other == null)
                return 0;
            int value = other.score - this.score;
            return value;
        }
        public override string ToString()//debug用
        {
            return score.ToString();
        }


    }
}