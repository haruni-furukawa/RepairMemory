using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public void CreateEnemies(string prefabName, int count, float x, float y)
    {
        var prefab = (GameObject)Resources.Load("Prefabs/" + prefabName);
        var objEnemy = Instantiate(prefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        //cardView = objCard.GetComponent(typeof(FollowerCardView)) as FollowerCardView;
        //Instantiate(p)
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
