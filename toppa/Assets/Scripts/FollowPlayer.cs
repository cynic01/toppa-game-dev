using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 offset;

    private Vector3 rotation_store;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X"));
        transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0, Space.Self);
        offset = transform.position - player.transform.position;
    }
}
