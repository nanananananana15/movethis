using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour
{
    //敵プレハブ
    public GameObject enemyPrefab;
    Vector3 vector3;

    public void createEnemy()
    {
        vector3 = new Vector3(Random.Range(-5.0f, 5.0f), transform.position.y, transform.position.z);

        // Enemyを作成する
        
        GameObject Enemy = Instantiate(enemyPrefab);
        float x = Random.Range(0, 6);
        float y = Random.Range(0, 6);
        Enemy.transform.position = new Vector3(x, y, 0);
    }
}