using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject particle;

    private void OnCollisionEnter(Collision collision)
    {
        impact();
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void impact()
    {
        GameObject hit = Instantiate(particle, transform.position, transform.rotation);
    }
}
