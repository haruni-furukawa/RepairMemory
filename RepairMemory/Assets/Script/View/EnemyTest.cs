using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTest : MonoBehaviour
{
    // 列挙型宣言
    public enum EnemyState
    {
        idle = 0, // 待機状態
        patrol = 1, // 探索状態
        outside = 2, // エリア外状態
        battle = 3, // 戦闘状態
        death = 4, // 死亡状態
    }

    // 定数宣言
    protected const float MOVE_SPEED = 10.0f; // 移動速度
    protected const float MIN_ACTION_TIME = 1.0f; // 次のアクションまでの最小時間
    protected const float MAX_ACTION_TIME = 5.0f; // 次のアクションまでの最小時間
    protected const float LIMIT_PATROL_AREA = 30.0f; // 行動範囲
    // グローバル変数宣言
    public Image imgHp;
    public int maxHp = 3;
    public int hp = 3;
    // ローカル変数宣言
    protected Player player;
    protected Vector3 _originPosition;
    protected EnemyState _currentState = EnemyState.idle;
    protected float _nextActionTime = 0.0f;
    protected float _actionTimer = 0.0f;
    public Queue<GameObject> objHit = new Queue<GameObject> ();

    public void SetPlayer (Player player) { this.player = player; }
    public virtual void SetNextTime () { _nextActionTime = Random.Range (MIN_ACTION_TIME, MAX_ACTION_TIME); }
    void Start ()
    {
        _originPosition = transform.position;
        SetNextTime ();
    }

    void Update () { EnemyAction (); }
    protected virtual void EnemyAction ()
    {
        _actionTimer += Time.deltaTime;
        switch (_currentState)
        {
            case EnemyState.idle:
                IdleAction ();
                break;
            case EnemyState.patrol:
                PatrolAction ();
                break;
            case EnemyState.outside:
                OutsideAction ();
                break;
            case EnemyState.battle:
                BattleAction ();
                break;
            case EnemyState.death:
                DeathAction ();
                break;
            default:
                break;
        }
        if (_actionTimer > _nextActionTime) { _actionTimer = 0; }
    }

    // 行動可能か否か
    protected bool IsActionable () { return _actionTimer > _nextActionTime; }
    public void OnEnterBattleTarget () { if (_currentState != EnemyState.battle) { _currentState = EnemyState.battle; } }
    public void OnExitBattleTarget () { if (_currentState == EnemyState.battle) { _currentState = EnemyState.idle; } }

    protected virtual void IdleAction ()
    {
        // TODO 待機状態の処理
        // 次のアクション時に探索状態に遷移させて、向き先を決める
    }
    protected virtual void PatrolAction ()
    {
        // TODO 探索状態の処理
        // TODO 次のアクションまで、定められた方向に進む
    }
    protected virtual void OutsideAction ()
    {
        // TODO エリア外状態の処理
        // バトル時でなく、エリア外であればエリア内に戻って待機に遷移
    }
    protected virtual void BattleAction ()
    {
        // TODO 戦闘状態の処理
        // 一定距離を保ってプレイヤーについていく
    }
    protected virtual void DeathAction ()
    {
        // TODO 死亡状態の処理 通常のタイマーとは違う処理で削除を行う？
    }
}