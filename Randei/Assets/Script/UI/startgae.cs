using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class startgae : MonoBehaviour
{
    //[Header("���������Ч")]
    // public AudioClip _audioClip;

    public void OnClickStartGame()
    {
        //�л�����
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

}