using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public Player player;

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

    // Start is called before the first frame update
    void Start ()
    {
        CreateEnemies ("Enemy1", 10, 0, 0);
        // SoundManager.Instance.PlayNormalBattleBgm ();
        //CreateEnemies ("Enemy1", 10, 0, 0);
        //CreateEnemies("Enemy2", 10, 0, 0);
        //CreateEnemies("Enemy3", 5, 10, 10);
    }

    // Update is called once per frame
    void Update ()
    {

    }
}