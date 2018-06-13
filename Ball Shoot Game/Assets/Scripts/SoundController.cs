using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour {
    private AudioSource menuAudio;
    private AudioSource clickAudio;
    
    public Slider musicSlider;
    public Slider clickSlider;

    public AudioClip menuSound;
    public AudioClip menuClickSound;

    private bool isPlaying;

    void Start() {

        AudioSource[] audios = GetComponents<AudioSource>();

        menuAudio = audios[0];
        menuAudio.loop = true;
        menuAudio.clip = menuSound;

       // menuAudio.volume = musicSlider.value;
        menuAudio.Play();

        // ToDo : Add sounds for clicks, damage, etc
        clickAudio = audios[1];
        clickAudio.clip = menuClickSound;
        clickAudio.loop = false;

       // clickAudio.volume = clickSlider.value;

    }

    public void PlayMenuSound()
    {
        if (menuAudio.isPlaying) return;
        menuAudio.Play();
    }

    public void PlayClickSound()
    {
        if (clickAudio.isPlaying) return;
        clickAudio.Play();
    }


    public void setMusicVolume()
    {
        menuAudio.volume = musicSlider.value;
    }

    public void setClickVolume()
    {
        clickAudio.volume = clickSlider.value;
    }


}

