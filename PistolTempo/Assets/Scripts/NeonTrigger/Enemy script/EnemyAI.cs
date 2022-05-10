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

    
    void Update()
    {
        enemyAgent.SetDestination(randomNavigation(walkRadius));
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
    }


}
