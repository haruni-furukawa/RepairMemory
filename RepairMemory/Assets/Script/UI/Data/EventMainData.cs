using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventMainData
{
    public List<EventMainModel> list = new List<EventMainModel>();
}

[Serializable]
public class EventMainModel
{
    public int id;
    public float x;
    public float z;
    public EventType type;
    public int eventId;

    public Vector3 GetPosition()
    {
        return new Vector3(x, 0.0f, z);
    }
}

[Serializable]
public enum EventType
{
    Serif = 0,
    Enemy = 10,
    BossEnemy = 11
}