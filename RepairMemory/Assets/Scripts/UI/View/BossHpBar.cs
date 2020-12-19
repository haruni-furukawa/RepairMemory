using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossHpBar : MonoBehaviour
{
    private const float DELAY_TIME = 2.0f;
    public Image hpBar;
    private bool InitializeHp = false;
    private float timeCount = 0.0f;

    void Start()
    {
        hpBar.fillAmount = 0.0f;
        SoundManager.Instance?.StopAllBgm();
    }

    void Update()
    {
        if (InitializeHp == false)
        {
            timeCount += Time.deltaTime;
            if (timeCount < DELAY_TIME)
            {
                hpBar.fillAmount = timeCount / DELAY_TIME;
            }
            else
            {
                hpBar.fillAmount = 1.0f;
                timeCount = 0.0f;
                InitializeHp = true;
                SoundManager.Instance?.PlayBossBattleBgm();
            }
        }
    }

    public void SetHpBar(float hp)
    {
        if (InitializeHp)
        {
            if (hpBar != null)
            {
                hpBar.fillAmount = hp;
            }
        }
    }
}