using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.VirtualTexturing;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private float detectionRange = 20f;
    private int damage = 5;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distancePlayer = Vector3.Distance(player.position, transform.position);
        if (distancePlayer < detectionRange)
        {
            agent.SetDestination(player.position);
        }
    }
}
