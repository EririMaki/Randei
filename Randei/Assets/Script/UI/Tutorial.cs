using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Tutorial : MonoBehaviour
{
    //[Header("���������Ч")]
    // public AudioClip _audioClip;

    public void OnClickStartGame()
    {
        //�л�����
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

}