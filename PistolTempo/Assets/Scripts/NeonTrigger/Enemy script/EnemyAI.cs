using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
   
    [SerializeField] private float walkRadius;
    [SerializeField] private LayerMask walkArea, thePlayer;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float delay;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private float attackRange, sightRange;

    private Transform player;
    private NavMeshAgent enemyAgent;
    private bool attacked, inSightRange, inAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Checks to see if the player is in range of sight and attack
        inSightRange = Physics.CheckSphere(transform.position, sightRange, thePlayer);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, thePlayer);

        //Some conditions to make it so that the enemy patrolls and shoots at the player
        if(!inSightRange && !inAttackRange)
        {
            enemyAgent.SetDestination(randomNavigation(walkRadius));
        }
        if (inSightRange && inAttackRange)
        {
            Attack();
        }      
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
        {   //instatiates the enemy bullet on the shoot point, which is a seperate game object
            GameObject enemyShot = Instantiate(enemyBullet, shootPoint.transform.position, shootPoint.transform.rotation);
            enemyShot.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(bulletVelocity, 0, 0));

            //Makes it so that the enemy doesn't machine gun the player to death.
            attacked = true;
            Invoke(nameof(AttackDelay), delay);

        }
    }

    private void AttackDelay()
    {
        attacked = false;
    }


}
