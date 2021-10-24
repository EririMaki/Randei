using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rankinglist : BasePanel
{
    public GameObject Ranking;
    public GameObject StartPanel;
    
    
    public override void OnEnter()
    {
       
        StartPanel.SetActive(false);
        Ranking.SetActive(true);
    }
    public override void OnExit()
    {
        StartPanel.SetActive(true);
        Ranking.SetActive(false);
    }
    

    
}
