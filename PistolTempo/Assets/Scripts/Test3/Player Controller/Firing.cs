using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bullVelocity;


    private void Update()
    {
        if (Input.GetButtonDown("Shoot1"))
        {
            GameObject ball = Instantiate(bullet, transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(bullVelocity, 0, 0));
        }
    }

}
