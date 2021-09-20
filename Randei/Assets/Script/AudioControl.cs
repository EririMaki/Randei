using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioControl : MonoBehaviour
{
    public Slider slider;
    public Toggle toggle;
    public AudioSource BGsound;

   public void ControlAudio()
    {
        if(toggle.isOn)
        {
            //激活声音自动播放
            BGsound.gameObject.SetActive(true);
            Volume();
        }
        else
        {
            BGsound.gameObject.SetActive(false);
        }
    }

    //滚动条控制音量
    public void Volume()
    {
        BGsound.volume = slider.value;
    }
}
