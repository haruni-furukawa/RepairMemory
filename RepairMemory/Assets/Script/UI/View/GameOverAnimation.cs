using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameOverAnimation : MonoBehaviour
{
    private UnityAction _callback;
    public void Play (UnityAction callback)
    {
        _callback = callback;
        GetComponent<Animator> ().SetTrigger ("Play");
    }
    public void OnEndAnimation ()
    {
        if (_callback != null)
        {
            _callback ();
        }
    }
}