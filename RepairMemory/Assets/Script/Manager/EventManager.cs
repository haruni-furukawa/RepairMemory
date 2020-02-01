using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private const float EVENT_DISTANCE = 12.5f;
    public static EventManager Instance { get; private set; }
    public IngameManager ingameManager;
    public UIManager uiManager;

    public PlayData playData;

    private List<UnityAction> queueFunc = new List<UnityAction> ();
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

    void Update ()
    {
        CheckFlag ();
        ExeFunc ();
    }

    void CheckFlag ()
    {
        foreach (EventMainModel model in GameDataManager.eventMainData.list)
        {
            if (playData.eventFlg[model.id] == false)
            {
                Vector2 playerPos = new Vector2 (ingameManager.player.transform.position.x, ingameManager.player.transform.position.z);
                Vector2 eventPos = new Vector2 (model.GetPosition ().x, model.GetPosition ().z);

                if (Vector2.Distance (playerPos, eventPos) < EVENT_DISTANCE)
                {
                    switch (model.type)
                    {
                        case EventType.Serif:
                            AddSerifFunc (model.eventId);
                            break;
                        case EventType.Enemy:
                            AddEnemyFunc (model.eventId, model.GetPosition ().x, model.GetPosition ().z);
                            break;
                        case EventType.BossEnemy:
                            AddBossEnemyFunc (model.eventId, model.GetPosition ().x, model.GetPosition ().z);
                            break;
                    }
                    playData.eventFlg[model.id] = true;
                }
            }
        }
    }

    void AddSerifFunc (int id)
    {
        foreach (EventSerifModel model in GameDataManager.eventSerifData.list)
        {
            if (model.id == id)
            {
                queueFunc.Add (() =>
                {
                    uiManager.ShowMessageWindow (model.serifText, model.imageName, model.voiceName);
                });
                break;
            }
        }
    }

    void AddEnemyFunc (int id, float x, float z)
    {
        foreach (EventEnemyModel model in GameDataManager.eventEnemyData.list)
        {
            if (model.id == id)
            {
                queueFunc.Add (() =>
                {
                    ingameManager.CreateEnemies (model.prefabName, model.count, x, z);
                });
                break;
            }
        }
    }

    void AddBossEnemyFunc (int id, float x, float z)
    {
        foreach (EventBossEnemyModel model in GameDataManager.eventBossEnemyData.list)
        {
            if (model.id == id)
            {
                queueFunc.Add (() =>
                {
                    // SoundManager.Instance.PlayBossBattleBgm ();
                    ingameManager.CreateBoss (model.prefabName, 1, x, z);
                });
                break;
            }
        }

    }

    void ExeFunc ()
    {
        foreach (UnityAction func in queueFunc)
        {
            func ();
        }
        queueFunc.Clear ();
    }
}