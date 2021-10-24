using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operating : BasePanel
{
    public GameObject OperatingPanel;
    public GameObject StartPanel;


    public override void OnEnter()
    {

        StartPanel.SetActive(false);
        OperatingPanel.SetActive(true);
    }
    public override void OnExit()
    {
        
        OperatingPanel.SetActive(false);
        StartPanel.SetActive(true);
    }
}
