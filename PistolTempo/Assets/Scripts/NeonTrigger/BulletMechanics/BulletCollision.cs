using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    [SerializeField] private GameObject particle;
    private void OnCollisionEnter(Collision collision)
    {
        particleImpact();

        if(collision.gameObject.tag == "Enemy")
        {
            GameObject bullet = this.gameObject;
            Destroy(bullet);
        }

    }

    public void particleImpact()
    {
        //Play the particle effect
        GameObject impact = Instantiate(particle, transform.position, transform.rotation);

    }

}
