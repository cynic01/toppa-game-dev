using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // The GameObject to be spawned
    public GameObject go;
    // Track the total number of enemies
    public int enenmyCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // The time before first enemy is spawned
    private float CreateTime = 3f;
    // Update is called once per frame
    void Update()
    {
        // Count down
        CreateTime -= Time.deltaTime;
        // Spawn an object in the given space
        if  (CreateTime <= 0 && enenmyCount < 4) {
            GameObject go2 = Instantiate(go, new Vector3(Random.Range(0f,10f),1,Random.Range(0f,10f)), Quaternion.identity);
            CreateTime = Random.Range(3,10);
            enenmyCount += 1;
        }   
    }
}
