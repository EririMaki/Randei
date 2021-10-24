using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Button : MonoBehaviour
{
    //the ButtonPauseMenu
    public GameObject ingameMenu;
    public GameObject Rankinglist;
    public void OnPause()//点击“暂停”时执行此方法
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }
    public void OnResume()
    {//点击“回到游戏”时执行此方法
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }
    public void OnRestart()
    {//点击“重新开始”时执行此方法
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void OnDuoRestart()
    {//点击“重新开始”时执行此方法
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void OnBacktoMenu()
    {//点击“重新开始”时执行此方法
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }

}