using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData : MonoBehaviour
{
    public static PlayData Instance { get; private set; }

    public Dictionary<int, bool> eventFlg = new Dictionary<int, bool> ();
    void Awake ()
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

    void Start ()
    {
        InitializeEventFlg ();
    }
    void InitializeEventFlg ()
    {
        foreach (EventMainModel model in GameDataManager.eventMainData.list)
        {
            eventFlg.Add (model.id, false);
        }
    }
}