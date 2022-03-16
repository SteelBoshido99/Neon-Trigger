using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bullet2;

    private int bulletNum;

    private GameObject chosenBullet;

    [SerializeField] private float bullVelocity;

    private void Start()
    {
        bulletNum = 1;
        chosenBullet = bullet;
    }


    private void Update()
    {
        if (bulletNum == 2 || Input.GetButtonDown("Change"))
        {           
            chosenBullet = bullet;
            bulletNum = 1;
        }

        if (bulletNum == 1 || Input.GetButtonDown("Change"))
        {         
            chosenBullet = bullet2;
            bulletNum = 2;
        }


        if (Input.GetButtonDown("Shoot1"))
        {
            GameObject ball = Instantiate(chosenBullet, transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(bullVelocity, 0, 0));
        }
    }

}
