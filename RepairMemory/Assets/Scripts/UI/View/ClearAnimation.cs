using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearAnimation : MonoBehaviour
{
    public void Play()
    {
        GetComponent<Animator>().SetTrigger("Play");
    }
    public void OnEndAnimation()
    {
        SoundManager.Instance.StopAllBgm();
        SceneManager.LoadScene("Clear");
    }
}