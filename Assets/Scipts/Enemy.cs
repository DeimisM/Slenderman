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
    public Animator animator;

    Rigidbody rb;
    NavMeshAgent agent;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target == null) return;

        agent.speed = speed;
        var currentSpeed = agent.velocity.magnitude;
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < 1.5f)
        {
            //jumpscare
            speed = 0;

            animator.Play("Scream");
        }

        else if (currentSpeed == 0)
        {
            animator.Play("Idle");
        }

        else if (currentSpeed < 4)
        {
            animator.Play("Walk");
        }

        else
        {
            animator.Play("Run");
        }

        //transform.LookAt(target);
        ////transform.position += transform.forward * speed * Time.deltaTime;
        //rb.velocity = transform.forward * speed;



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

    }
}
