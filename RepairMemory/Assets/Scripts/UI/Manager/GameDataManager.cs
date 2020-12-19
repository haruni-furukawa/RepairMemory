using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; }
    public static EventMainData eventMainData { get; private set; }
    public static EventSerifData eventSerifData { get; private set; }
    public static EventEnemyData eventEnemyData { get; private set; }
    public static EventBossEnemyData eventBossEnemyData { get; private set; }
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

    private void InitializeGameDataManager()
    {
        eventMainData = LoadData<EventMainData>("EventMain");
        eventSerifData = LoadData<EventSerifData>("EventSerif");
        eventEnemyData = LoadData<EventEnemyData>("EventEnemy");
        eventBossEnemyData = LoadData<EventBossEnemyData>("EventBossEnemy");
    }

    private static T LoadData<T>(string fileName)
    {
        return JsonUtility.FromJson<T>(Resources.Load<TextAsset>(ResourceConst.JSON_PATH + fileName).ToString());
    }

    private void Start()
    {
        InitializeGameDataManager();
    }
}