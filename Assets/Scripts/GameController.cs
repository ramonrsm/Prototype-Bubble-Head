using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{

    public List<Transform> spawnEnemys;

    void Start()
    {
        SpawnEnemys();
    }

    void OnDisable()
    {
        
    }

    private void SpawnEnemys(){
        GameObject enemy = ObjectPool.instance.EnemyPrefab;

        for(int i = 0; i < spawnEnemys.Count; i++){

            int random = Random.Range(0, spawnEnemys.Count);
            ObjectPool.instance.reuseObjects(enemy, spawnEnemys[1]);
        }   
    }
}