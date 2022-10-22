using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        // transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + 1.6f, player.transform.position.z - 2f);
    }
}
