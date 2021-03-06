using System;
using System.Collections.Generic;

[Serializable] public class EventBossEnemyData
{
    public List<EventBossEnemyModel> list = new List<EventBossEnemyModel> ();
}

[Serializable] public class EventBossEnemyModel
{
    public int id;
    public string prefabName;
    public int count;
    public float x;
    public float z;
}