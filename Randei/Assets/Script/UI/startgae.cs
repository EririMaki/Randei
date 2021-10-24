using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class startgae : MonoBehaviour
{
    //[Header("鼠标移入声效")]
    // public AudioClip _audioClip;

    public void OnClickStartGame()
    {
        //切换场景
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

}