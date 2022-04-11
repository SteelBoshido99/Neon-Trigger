using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRicochet : MonoBehaviour
{
    [SerializeField] private float bulletLife = 3.0f;

    // Update is called once per frame
    void Update()
    {
        //Ray ray = new Ray(transform.position, transform.forward);
        //RaycastHit impact;

        //if (Physics.Raycast(ray, out impact, Time.deltaTime)){

        //}

        GameObject bullet = this.gameObject;
        Destroy(bullet, bulletLife);

    }
}
