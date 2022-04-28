using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRicochet : MonoBehaviour
{
    [SerializeField] private float bulletLife = 2.0f;
    [SerializeField] private LayerMask collision;
    
    void Update()
    {
        //Uses raycasting to hold the position and the direction the bullet is travelling in
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit impact;

        if (Physics.Raycast(ray, out impact, Time.deltaTime + 0.05f, collision))
        {
            //This then calculates the trajectory of the bullet after it hits another object (Not including enemies)
            Vector3 ricochetDir = Vector3.Reflect(ray.direction, impact.normal);
            float rotation = 90 - Mathf.Atan2(ricochetDir.z, ricochetDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }

        //Time of death for the bullet
        GameObject bullet = this.gameObject;
        Destroy(bullet, bulletLife);

    }
}
