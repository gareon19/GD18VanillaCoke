using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {

    private AudioSource musicAudio;
    private AudioSource clickAudio;

    public Slider musicSlider;
    public Slider clickSlider;

    public AudioClip menuSound;
    public AudioClip menuClickSound;

    public AudioSource ClickAudio
    {
        get
        {
            return clickAudio;
        }

        set
        {
            clickAudio = value;
        }
    }


    void Start() {
        DontDestroyOnLoad(this.gameObject);


        musicAudio = GetComponent<AudioSource>();

        musicAudio.loop = true;
        musicAudio.clip = menuSound;
        musicAudio.Play();

        // ToDo : Add sounds for clicks, damage, etc
        clickAudio = GetComponent<AudioSource>();

    }


    public void PlayMusic()
    {
        if (musicAudio.isPlaying) return;
        musicAudio.Play();
    }

    public void StopMusic()
    {
        musicAudio.Stop();
    }

    public void setMusicVolume()
    {
        musicAudio.volume = musicSlider.value;
    }

    public void setClickVolume()
    {
        clickAudio.volume = musicSlider.value;
    }



}

