using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip bgm;
    private AudioSource[] audioSources;
    private AudioSource bgmAudioSource;   // �̹� �������� BGM ������
    private bool isBGMOn = true;
    private bool isSFXOn = true;


    private void Awake()
    {
        // �̱���
        if(Instance == null)
        {
            Instance = this;
        }
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        audioSources = new AudioSource[5];
        for (int i=0; i < audioSources.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }
    

    public void PlayClip(AudioClip clip)
    {
        float playSpeed = 1.0f;
        PlayClip(clip, playSpeed);
    }
    public void PlayClip(AudioClip clip, float playSpeed)
    {
        if (!isSFXOn) return;
        foreach (AudioSource source in audioSources)
        {
            if (!source.isPlaying)
            {
                source.clip = clip;
                source.pitch = playSpeed;
                source.Play();
                return;
            }
        }
    }

    public void PlayBGM()
    {
        float playSpeed = 1.0f;
        PlayBGM(bgm, playSpeed);
    }
    public void PlayBGM(float playSpeed)
    {
        PlayBGM(bgm, playSpeed);
    }
    public void PlayBGM(AudioClip clip)
    {
        float playSpeed = 1.0f;
        PlayBGM(clip, playSpeed);
    }
    public void PlayBGM(AudioClip clip, float playSpeed)
    {
        if(!isBGMOn) return;
        if(bgmAudioSource.isPlaying)bgmAudioSource.Stop();
        bgmAudioSource.clip = clip;
        bgmAudioSource.pitch = playSpeed;
        bgmAudioSource.loop = true;
        bgmAudioSource.Play();
    }

    public void StopBGM()
    {
        if(bgmAudioSource.isPlaying)bgmAudioSource.Stop();
    }
    
    public void TurnOffBGM()
    {
        isBGMOn = false;
        StopBGM();
    }

    public void TurnOffSFX()
    {
        isSFXOn = false;
        for(int i=0; i < audioSources.Length; i++)
        {
            if(audioSources[i].isPlaying) audioSources[i].Stop();
        }
    }
}
