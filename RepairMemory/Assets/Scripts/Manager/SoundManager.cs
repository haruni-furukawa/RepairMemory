using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> bgmList = new List<AudioSource>();
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    public void StopAllBgm()
    {
        foreach (AudioSource audioSource in bgmList)
        {
            audioSource.Stop();
        }
    }

    // TODO フェード
    public void PlayNormalBattleBgm()
    {
        foreach (AudioSource audioSource in bgmList)
        {
            audioSource.Stop();
        }
        bgmList[0].Play();
    }

    public void PlayPinchBattleBgm()
    {
        foreach (AudioSource audioSource in bgmList)
        {
            audioSource.Stop();
        }
        bgmList[1].Play();
    }
    public void PlayBossBattleBgm()
    {
        foreach (AudioSource audioSource in bgmList)
        {
            audioSource.Stop();
        }
        bgmList[2].Play();
    }
}