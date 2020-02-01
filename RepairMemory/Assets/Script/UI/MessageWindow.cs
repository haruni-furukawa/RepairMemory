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

    private MessageStateType _stateType = MessageStateType.Stay;

    private string currentSentence = string.Empty; // 現在の文字列
    private float timeUntilDisplay = 0.1f; // 表示にかかる時間
    private float timeCount = 0.0f; // 時間計測

    private string _serifText = "";
    private string _standImagePath = "";
    private string _voiceFilePath = "";

    void ShowMessageWindow (string text, string standImagePath, string voiceFilePath)
    {
        _serifText = text;
        _standImagePath = standImagePath;
        _voiceFilePath = voiceFilePath;
        _stateType = MessageStateType.Initialze;
    }

    void InitialzeVariable ()
    {
        currentSentence = string.Empty;
        _stateType = MessageStateType.OpenAnimation;
    }
    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
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
        // TODO コールバック
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
        if (currentSentence.Length == _serifText.Length)
        {
            _stateType = MessageStateType.CloseAnimation;
        }
        else
        {
            timeCount += Time.deltaTime;
            if (timeCount >= timeUntilDisplay)
            {
                UpdateSerif ();
                timeCount = 0;
            }
        }
    }

    void UpdateSerif ()
    {

    }

    void PlayClose ()
    {
        // TODO コールバック
        _stateType = MessageStateType.SerifAnimation;
    }
}