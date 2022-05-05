using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bullet2;
    private Vector3 Rotation = new Vector3 (0, 0, -90);
    private bool bulletNum;
   

    private GameObject chosenBullet;

    [SerializeField] private float bullVelocity;

    private void Start()
    {
        chosenBullet = bullet;
        bulletNum = true;
    }


    private void Update()
    {
        if (Input.GetButtonDown("Switch")){
            bulletSwitch();
        }




        if (Input.GetButtonDown("Shoot1"))
        {
            //Creates an instance of pointed prefab
            GameObject newBullet = Instantiate(chosenBullet, transform.position, transform.rotation);

            newBullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(bullVelocity, 0, 0));
        }
    }



    private void bulletSwitch()
    {
        //logic to allow the player to switch between bullets
        if (!bulletNum)
        {
            chosenBullet = bullet;
            //Debug.Log("Back to the OG bullet");
            bulletNum = true;

        }
        else if (bulletNum)
        {
            chosenBullet = bullet2;
            //Debug.Log("Second bullet");
            bulletNum = false;
        }
    }

}
