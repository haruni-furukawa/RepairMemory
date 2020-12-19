using System;
using UnityEngine;

public class MonoBase<T> : MonoBehaviour where T : MonoBehaviour
{
    // オブジェクトインスタンスの保持
    private static T _instance;

    // オブジェクトインスタンス
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);

                _instance = (T)FindObjectOfType(t);
                if (_instance == null) { Debug.Log(t + " をアタッチしているGameObjectはありません"); }
            }
            return _instance;
        }
    }

    // 他のゲームオブジェクトにアタッチされているか調べる
    virtual protected void Awake()
    {
        // アタッチされている場合は破棄する。
        CheckInstance();
    }

    // インスタンスの確認、破棄
    protected bool CheckInstance()
    {
        if (_instance == null) { _instance = this as T; return true; }
        else if (Instance == this) { return true; }
        Destroy(this);
        return false;
    }
}