using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public Player player;
    public UIManager uiManager;

    public void CreateEnemies (string prefabName, int count, float x, float z)
    {
        for (var i = 0; i < count; i++)
        {
            var prefab = (GameObject) Resources.Load ("Prefab/" + prefabName);
            var newX = x + Random.Range (-10f, 10f);
            var newZ = z + Random.Range (-10f, 10f);
            var objEnemy = Instantiate (prefab, new Vector3 (newX, 0.0f, newZ), Quaternion.identity);
            var enemy = objEnemy.GetComponent<Enemy> ();
            enemy.SetPlayer (player);
        }
    }
    public void CreateBoss (string prefabName, int count, float x, float z)
    {
        var prefab = (GameObject)Resources.Load("Prefab/" + prefabName);
        var newX = x;
        var newZ = z;
        var objEnemy = Instantiate(prefab, new Vector3(newX, 0.0f, newZ), Quaternion.identity);
        var enemy = objEnemy.GetComponent<Enemy5>();
        enemy.SetUIManager(uiManager);
        enemy.SetPlayer(player);
    }
    // Start is called before the first frame update
    void Start ()
    {
        //CreateEnemies ("Enemy5", 1, 0, 0);

        // SoundManager.Instance.PlayNormalBattleBgm ();
        //CreateEnemies ("Enemy1", 10, 0, 0);
        //CreateEnemies("Enemy2", 10, 0, 0);
        CreateEnemies("Enemy11", 5, 10, 10);
        //CreateBoss("Enemy5", 1, 10, 0);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}