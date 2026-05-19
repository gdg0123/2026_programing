using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip audioClip;           //사운드 파일
    public AudioClip audioBGMClip;        //배경 사운드 파일
    private AudioSource audioSource;      //사운드 재생
    private AudioSource audioSourceBGM;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceBGM = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void PlayBGMSound()
    {
        audioSourceBGM.clip = audioBGMClip;
        audioSourceBGM.loop = true;
        audioSourceBGM.Play();
    }


    public void OnOffBGM(bool isOn)
    {
        if (isOn)
        {
            audioSourceBGM.volume = 1;
        }
        else
        {
            audioSourceBGM.volume = 0;
        }
    }

    public void OnOffFx(bool isOn)
    {
        if (isOn)
        {
            audioSource.volume = 1;
        }
        else
        {
            audioSource.volume = 0;
        }
    }

    public void ChangeBGMVolume(float volume)
    {
        audioSourceBGM.volume = volume;
    }

    public void ChangeFxVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
