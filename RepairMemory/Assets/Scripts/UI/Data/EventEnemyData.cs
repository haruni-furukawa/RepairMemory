using System;
using System.Collections.Generic;

[Serializable]
public class EventEnemyData
{
    public List<EventEnemyModel> list = new List<EventEnemyModel>();
}

[Serializable]
public class EventEnemyModel
{
    public int id;
    public string prefabName;
    public int count;
    public float x;
    public float z;
    public string GetprefabName()
    {
        return prefabName;
    }
}