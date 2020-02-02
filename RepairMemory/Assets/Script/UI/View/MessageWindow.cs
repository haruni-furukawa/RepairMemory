using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : MonoBehaviour
{
    public enum MessageStateType
    {
        Stay = 100,
        Initialze = 0,
        OpenAnimation = 10,
        PlayVoice = 20,
        SerifAnimation = 30,
        CloseAnimation = 40
    }
    public Image stand;
    public Text message;
    public AudioSource _audioSource;
    public Animator _animator;
    private MessageStateType _stateType = MessageStateType.Stay;

    private string currentSentence = string.Empty; // 現在の文字列
    private float timeUntilDisplay = 0.2f; // 表示にかかる時間
    private float timeCloseDisplay = 2.0f; // クローズ時間
    private float timeCount = 0.0f; // 時間計測

    private string _serifText = "";
    private string _voiceFilePath = "";

    private bool _clearFlag = false;

    public void ShowMessageWindow (string text, string standImageFileName, string voiceFileName, bool clearFlag = false)
    {
        _serifText = text;
        stand.sprite = null;
        _clearFlag = clearFlag;
        if (standImageFileName.Length > 0) stand.sprite = Resources.Load<Sprite> ("Image/Character/Stand/" + standImageFileName);
        _voiceFilePath = voiceFileName.Length > 0 ? "Sound/Voice/" + voiceFileName : "";
        _stateType = MessageStateType.Initialze;
    }

    void InitialzeVariable ()
    {
        currentSentence = string.Empty;
        _stateType = MessageStateType.OpenAnimation;
    }

    void Update ()
    {
        switch (_stateType)
        {
            case MessageStateType.Initialze:
                InitialzeVariable ();
                break;
            case MessageStateType.OpenAnimation:
                PlayOpen ();
                break;
            case MessageStateType.PlayVoice:
                PlayVoice ();
                break;
            case MessageStateType.SerifAnimation:
                PlaySerif ();
                break;
            case MessageStateType.CloseAnimation:
                PlayClose ();
                break;
            case MessageStateType.Stay:
            default:
                break;
        }
    }

    void PlayOpen ()
    {
        _animator.SetBool ("IsOpen", true);
        _stateType = MessageStateType.PlayVoice;
    }

    void PlayVoice ()
    {
        if (_audioSource != null && _voiceFilePath != "")
        {
            AudioClip voice = Resources.Load<AudioClip> (_voiceFilePath);
            _audioSource.PlayOneShot (voice);
        }
        _stateType = MessageStateType.SerifAnimation;
    }
    void PlaySerif ()
    {
        timeCount += Time.deltaTime;
        if (currentSentence.Length == _serifText.Length)
        {
            if (timeCount >= timeCloseDisplay)
            {
                _stateType = MessageStateType.CloseAnimation;
                timeCount = 0;
            }
        }
        else
        {
            if (timeCount >= timeUntilDisplay)
            {
                UpdateSerif ();
                timeCount = 0;
            }
        }
    }

    void UpdateSerif ()
    {
        int currentDispIndex = currentSentence.Length;

        currentSentence += _serifText[currentDispIndex];
        message.text = currentSentence;
    }

    void PlayClose ()
    {
        _animator.SetBool ("IsOpen", false);
        _animator.SetBool ("IsClose", true);
    }

    public void OnEndClose ()
    {
        _animator.SetBool ("IsClose", false);
        _stateType = MessageStateType.Stay;
        if (_clearFlag)
        {
            Clear ();
        }
    }

    private void Clear ()
    {
        UIManager.Instance.ShowClear ();
    }
}