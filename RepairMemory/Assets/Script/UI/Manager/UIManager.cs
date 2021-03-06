﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<GameObject> memoryParts = new List<GameObject> ();
    public GameObject bossHpBarPos;
    public GameObject bossHpBarPrefab;
    public Image hpBar;
    public Image spBar;
    public Text banishCount;
    public MessageWindow messageWindow;
    public static UIManager Instance { get; private set; }

    public IngameManager inGameManager;

    public ClearAnimation clearAnimation;
    public GameOverAnimation gameOverAnimation;

    private BossHpBar bossHpBar;
    private AudioSource audioSource;
    public AudioClip soundGet;
    public void ShowClear ()
    {
        clearAnimation.Play ();
        // inGameManager.GameEndTimerStart("Clear");    //一定時間後にクリア画面に飛ばす
    }

    public void ShowGameOver ()
    {
        gameOverAnimation.Play ();
        // inGameManager.GameEndTimerStart("Credit");    //一定時間後にクレジット画面に飛ばす
    }

    public void ShowBossHpBar ()
    {
        GameObject bossHpBarObj = Instantiate (bossHpBarPrefab, bossHpBarPos.transform);
        bossHpBar = bossHpBarObj.GetComponent<BossHpBar> ();
    }

    public void SetBossHpBar (float hp)
    {
        if (bossHpBar != null)
        {
            hp = CheckSliderValue (hp);
            bossHpBar.SetHpBar (hp);
        }
    }

    public void HideBossHpBar ()
    {
        Destroy (bossHpBar.gameObject);
        bossHpBar = null;
    }

    public void ShowMessageWindow (string text, string standImageFileName, string voiceFileName, bool clearFlag = false)
    {
        messageWindow.ShowMessageWindow (text, standImageFileName, voiceFileName, clearFlag);
    }
    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy (this);
            return;
        }
    }

    private void Start () { audioSource = GetComponent<AudioSource> (); }

    public void SetMemoryParts (int index)
    {
        if (0 < index && index < memoryParts.Count) { audioSource.PlayOneShot (soundGet); }
        if (0 <= index && index < memoryParts.Count)
        {
            foreach (GameObject parts in memoryParts) parts.SetActive (false);
            memoryParts[index].SetActive (true);
        }
    }

    public void SetHpBar (float hp)
    {
        hp = CheckSliderValue (hp);
        if (hpBar != null)
        {
            hpBar.fillAmount = hp;
        }
    }

    public void SetSpBar (float sp)
    {
        sp = CheckSliderValue (sp);
        if (spBar != null)
        {
            spBar.fillAmount = sp;
        }
    }

    private float CheckSliderValue (float value)
    {
        if (value > 1.0f)
        {
            value = 1.0f;
        }
        if (value < 0.0f)
        {
            value = 0.0f;
        }
        return value;
    }

    public void SetBanishCount (int count)
    {
        if (banishCount != null)
        {
            banishCount.text = count.ToString ();
        }
    }
}