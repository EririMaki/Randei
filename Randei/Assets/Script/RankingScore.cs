using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingScore : MonoBehaviour
{
    private GameController _gameController;
    private Text ScoreText;
    private void Awake()
    {

    }
    private void Start()
    {
        _gameController = GetComponent<GameController>();
        ScoreText = GameObject.Find("Prefab/Score").GetComponent<Text>();
        //ScoreText.text = _gameController.Score.ToString();
        ScoreText.text = PlayerPrefs.GetInt("High").ToString();
    }
    private void Update()
    {



    }

}
