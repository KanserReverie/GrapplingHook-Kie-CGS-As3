using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;
    public Transform[] waypoints;
    private void Start()
    {
        NavMeshAgent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        
    }
}
