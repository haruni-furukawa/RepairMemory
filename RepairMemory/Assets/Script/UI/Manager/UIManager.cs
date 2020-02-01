using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public List<GameObject> memoryParts = new List<GameObject> ();
    public Slider hpBar;
    public Slider spBar;
    public Text killCount;
    public static UIManager Instance { get; private set; }
    // public 
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

    public void SetMemoryParts (int index)
    {
        if (0 <= index && index < memoryParts.Count)
        {
            foreach (GameObject parts in memoryParts) parts.SetActive (false);
            memoryParts[index].SetActive (true);
        }
    }

    public void SetHpBar (float hp)
    {
        hp = CheckSliderValue (hp);
        if (hpBar != null)
        {
            hpBar.value = hp;
        }
    }

    public void SetSpBar (float sp)
    {
        sp = CheckSliderValue (sp);
        if (spBar != null)
        {
            spBar.value = sp;
        }
    }

    private float CheckSliderValue (float value)
    {
        if (value > 1.0f)
        {
            value = 1.0f;
        }
        if (value < 0.0f)
        {
            value = 0.0f;
        }
        return value;
    }

    public void SetKillCount (int count)
    {
        if (killCount != null)
        {
            killCount.text = count.ToString ();
        }
    }
}