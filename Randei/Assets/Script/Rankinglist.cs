using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RankingList : MonoBehaviour
{
    private GameObject gameController;
    private void Awake()
    {
        gameController = GameObject.Find("GameController");
    }
    public void Ranking()
    {
        //�����а��Panel����
        gameController.transform.GetChild(1).gameObject.SetActive(true);
    }

}
