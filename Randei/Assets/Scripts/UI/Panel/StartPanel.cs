using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XFramework;
using XFramework.Extend;
using UnityEngine.SceneManagement;

/// <summary>
/// 开始面板
/// </summary>
public class StartPanel : BasePanel
{
    /// <summary>
    /// 路径
    /// </summary>
    static readonly string path = "Prefabs/UI/Panel/StartPanel";

    /// <summary>
    /// 开始面板
    /// </summary>
    public StartPanel() : base(new UIType(path))
    {

    }

    protected override void InitEvent()
    {
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnSetting").onClick.AddListener(() =>
        {
            Push(new SettingPanel());
        });
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnGame").onClick.AddListener(() =>
        {
            Push(new LevelPanel());
        });
        ActivePanel.GetOrAddComponentInChildren<Button>("BtnPlay").onClick.AddListener(() =>
        {           //Game.LoadScene(new MainScene());//
            SceneManager.LoadScene(2);
        });
                ActivePanel.GetOrAddComponentInChildren<Button>("BtnMsg").onClick.AddListener(() =>
        {
            Push(new TaskPanel());
        });
    }
}
