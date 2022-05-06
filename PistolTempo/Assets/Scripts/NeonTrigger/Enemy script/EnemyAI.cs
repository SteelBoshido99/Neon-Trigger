using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemyAgent;
    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(randomNavigation(4f));
    }

    //This gets a random point in the navmesh
    public Vector3 randomNavigation(float radius)
    {
        Vector3  randomPoint = Random.insideUnitSphere * radius;
        randomPoint += transform.position;
        NavMeshHit hit;
        Vector3 finalPos = Vector3.zero;
        if(NavMesh.SamplePosition(randomPoint, out hit, radius, 1))
        {
            finalPos = hit.position;
        }
        return finalPos;
    }

}
