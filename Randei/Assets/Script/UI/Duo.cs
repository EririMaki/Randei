using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Duo : MonoBehaviour
{
    //[Header("���������Ч")]
    // public AudioClip _audioClip;

    public void OnClickStartGame()
    {
        //�л�����
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

}