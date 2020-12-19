using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ClearAnimation : MonoBehaviour
{
    private bool _isPlaying = false;
    private bool _isProcessed = false;

    void Start() { Play(); }
    public void Play()
    {
        if (_isPlaying || _isProcessed) { return; }

        _isPlaying = true;
        float duration = 1.0f / 6.0f;
        float delayTime = 1.0f;
        Vector3 initializeScale = Vector3.one;
        initializeScale.y = 0.0f;
        transform.transform.localScale = initializeScale;

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScaleY(1.0f, duration).SetLink(gameObject));
        seq.AppendInterval(delayTime);
        seq.Append(transform.DOScaleY(0.0f, duration).SetLink(gameObject));
        seq.AppendCallback(() => OnEndAnimation());
    }

    private void OnEndAnimation()
    {
        _isPlaying = false;
        _isProcessed = true;
        SoundManager.Instance?.StopAllBgm();
        SceneManager.LoadScene("Clear");
    }
}