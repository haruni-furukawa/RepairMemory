using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBase<SoundManager>
{
    public List<AudioSource> bgmList = new List<AudioSource>();
    override protected void Awake() { if (CheckInstance()) { DontDestroyOnLoad(this); } }

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