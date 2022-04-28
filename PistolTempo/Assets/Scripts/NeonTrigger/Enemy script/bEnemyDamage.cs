using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bEnemyDamage : MonoBehaviour
{
    private int enemyCurrent;
    [SerializeField] private int mxEnemyHealth = 50;
    [SerializeField] private int bulletDamage;


    private void Start()
    {
        enemyCurrent = mxEnemyHealth;
        Debug.Log("The enemy health is at: " + enemyCurrent);
    }

    void Update()
    {
        enemyCurrent = Mathf.Clamp(enemyCurrent, 0, mxEnemyHealth);
        if(enemyCurrent == 0)
        {
            GameObject mob = this.gameObject;
            Destroy(mob);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            EnemyDamge(bulletDamage * 2);

        }
        else if (collision.gameObject.tag == "Blue")
        {
            EnemyDamge(bulletDamage / 2);
        }

    }


    public void EnemyDamge(int damage)
    {
        enemyCurrent -= damage;
        Debug.Log("The enemy has taken " + damage + " damage");
    }
}
