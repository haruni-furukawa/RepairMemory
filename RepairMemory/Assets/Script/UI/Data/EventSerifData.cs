using System;
using System.Collections.Generic;

[Serializable] public class EventSerifData
{
    public List<EventSerifModel> list = new List<EventSerifModel> ();
}

[Serializable] public class EventSerifModel
{
    public int id;
    public string serifText;
    public string voiceName;
    public string imageName;
    public int GetId ()
    {
        return id;
    }
    public string GetSerifText ()
    {
        return serifText;
    }
    public string GetVoiceName ()
    {
        return voiceName;
    }
    public string GetImageName ()
    {
        return imageName;
    }
}