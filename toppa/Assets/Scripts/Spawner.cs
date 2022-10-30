using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The GameObject to be spawned")]
    private GameObject go;

    [SerializeField]
    [Tooltip("The time before first enemy is spawned")]
    private float CreateTime;

    [SerializeField]
    [Tooltip("The total number of enemies to spawn")]
    private int enemyCount;
    
    // Update is called once per frame
    void Update()
    {
        if (enemyCount <= 0) return;
        // Count down
        CreateTime -= Time.deltaTime;
        // Spawn an object in the given space
        if (CreateTime <= 0) {
            GameObject go2 = Instantiate(go, new Vector3(Random.Range(0f, 10f), -1, Random.Range(0f, 10f)), Quaternion.identity);
            CreateTime = Random.Range(2, 5);
            enemyCount--;
        }
    }
}
