using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Operating : BasePanel
{
    public GameObject OperatingPanel;
    public GameObject StartPanel;
    public Text errorMessage;

    public override void OnEnter()
    {

        StartPanel.SetActive(false);
        OperatingPanel.SetActive(true);
        errorMessage.gameObject.SetActive(false);
    }
    public override void OnExit()
    {
        
        OperatingPanel.SetActive(false);
        StartPanel.SetActive(true);
    }
}
