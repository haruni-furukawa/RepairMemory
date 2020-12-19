using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    // ---------- 定数宣言 ----------
    // ---------- ゲームオブジェクト参照変数宣言 ----------
    // ---------- プレハブ ----------
    // ---------- プロパティ ----------
    [SerializeField, Tooltip("HPプログレスイメージ")] Image _hpProgressImage = default;
    // ---------- クラス変数宣言 ----------
    // ---------- インスタンス変数宣言 ----------
    private Camera _mainCamera = default;
    // ---------- Unity組込関数 ----------
    private void Start() { InitializeEnemyHPBar(); }
    private void Update() { UpdateEnemyHPBar(); }
    // ---------- Public関数 ----------

    // HPレートを設定
    public void SetHPRate(float rate) { _hpProgressImage.fillAmount = rate; }

    // アクティブ状態の設定
    public void SetActive(bool b) { gameObject.SetActive(b); }
    // ---------- Private関数 ----------

    // 初期化：
    private void InitializeEnemyHPBar()
    {
        _mainCamera = Camera.main;
        SetHPRate(1.0f);
    }

    // 毎フレーム更新：
    private void UpdateEnemyHPBar()
    {

        transform.LookAt(_mainCamera.transform);
        Vector3 targetEulerAngles = _mainCamera.transform.eulerAngles;
        targetEulerAngles.y += 180;
        transform.eulerAngles = targetEulerAngles;
    }
}
