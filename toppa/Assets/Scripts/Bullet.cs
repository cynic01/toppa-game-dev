using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Collider bullet_collider;
    
    // Start is called before the first frame update
    void Start()
    {
        bullet_collider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy") {
            // Debug.Log("Hit Enemy");
            collision.gameObject.GetComponent<EnemyHealth>().DecreaseHealth(101f);
        } else if (collision.gameObject.tag == "Player") {
            Debug.Log("Hit Player");
        }
    }
}
