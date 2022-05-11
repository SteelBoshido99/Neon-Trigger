using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyBulletCollision : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    private n3PlayerHealth playerDamage;

    private void OnCollisionEnter(Collision collision)
    {
        impact();
        if(collision.gameObject.tag == "Player")
        {
            playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<n3PlayerHealth>();
            playerDamage.TakeDamage(10f);

            Destroy(gameObject);
        }
    }

    private void impact()
    {
        GameObject hit = Instantiate(particle, transform.position, transform.rotation);
    }
}
