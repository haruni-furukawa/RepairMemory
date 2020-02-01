using System;
using System.Collections.Generic;

[Serializable] public class EventEnemyData
{
    public List<EventEnemyModel> list = new List<EventEnemyModel> ();
}

[Serializable] public class EventEnemyModel
{
    public int id;
    public string prefabName;
    public int count;
    public int GetId ()
    {
        return id;
    }
    public string GetprefabName ()
    {
        return prefabName;
    }
    public int GetCount ()
    {
        return count;
    }
}