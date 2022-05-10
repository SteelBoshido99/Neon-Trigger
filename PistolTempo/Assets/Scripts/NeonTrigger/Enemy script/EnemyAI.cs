using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private float walkRadius;
    [SerializeField] private LayerMask walkArea;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float delay;

    private bool attacked;
    private GameObject projectile;

    private void Start()
    {
        projectile = enemyBullet;
    }

    void Update()
    {
        enemyAgent.SetDestination(randomNavigation(walkRadius));
        Attack();
    }


    //This gets a random point in the navmesh
    public Vector3 randomNavigation(float moveRadius)
    {

        //Finds a random point using a unit sphere, which is then multiplied by the moveRadius variable.
        Vector3  randomPoint = Random.insideUnitSphere * moveRadius;
        randomPoint += transform.position;
        NavMeshHit hit;
        Vector3 finalPos = Vector3.zero;
        //Returns a bool to see if the neast point, has been found
        if(NavMesh.SamplePosition(randomPoint, out hit, moveRadius, 1))
        {
            finalPos = hit.position;
        }
        return finalPos;     
    }

    public void Attack()
    {
        enemyAgent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!attacked)
        {
            GameObject enemyShot = Instantiate(projectile, transform.position, transform.rotation);

            enemyShot.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(bulletVelocity, 0, 0));

            attacked = true;
            Invoke(nameof(AttackDelay), delay);

        }


    }


    private void AttackDelay()
    {
        attacked = false;
    }


}
