using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        // Copy from https://answers.unity.com/questions/324589/how-can-i-tell-when-a-navmesh-has-reached-its-dest.html
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Stop();
                }
            }
        }

		if(Input.GetKey(KeyCode.W)){
			transform.Translate(0, 0, agent.speed * Time.deltaTime);
        	RunAnimation(true);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(0, 0, -agent.speed * Time.deltaTime);
        	RunAnimation(true);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(0, 90 * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(0, -90 * Time.deltaTime, 0);
		}
    }

    public void GoTo(Transform target)
    {
        agent.SetDestination(target.position);
        RunAnimation(true);
    }

    public void Stop()
    {
        RunAnimation(false);
        agent.ResetPath();
    }

	void RunAnimation(bool flag){
		animator.SetBool("Run", flag);
	}

}
