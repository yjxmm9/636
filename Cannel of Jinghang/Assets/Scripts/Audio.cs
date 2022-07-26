using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{

    private AudioSource mainmenuaudio;
    public Slider audioVolume;

    private void Awake()
    {
        GameObject BGMUI = GameObject.Find("BGM");
        mainmenuaudio = BGMUI.GetComponent<AudioSource>();
    }

    public void OnSlideChange()
    {
        PlayerPrefs.SetFloat("AudioVolume", audioVolume.value);
        mainmenuaudio.volume = PlayerPrefs.GetFloat("AudioVolume", 0.274f);

    }
}
