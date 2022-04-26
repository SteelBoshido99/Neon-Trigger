using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float camY;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, camY, -3);
    }
}
