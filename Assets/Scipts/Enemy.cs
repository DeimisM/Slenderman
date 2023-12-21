using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows.Speech;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float viewDistance;
    public float wanderDistance;

    Rigidbody rb;
    NavMeshAgent agent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    private void Update()
    {
        //transform.LookAt(target);
        ////transform.position += transform.forward * speed * Time.deltaTime;
        //rb.velocity = transform.forward * speed;


        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < viewDistance)
        {
            //seek
            agent.destination = target.position;
        }

        else
        {
            //search
            if(agent.velocity == Vector3.zero)
            {
                var offset = Random.insideUnitSphere * wanderDistance;
                agent.destination = target.position + offset;
            }
        }

        if (distance < 1f)
        {
            //jumpscare
        }
    }
}
