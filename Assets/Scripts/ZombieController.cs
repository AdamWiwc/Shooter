using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour 
{

	Animator animator;
	GameObject target;
	public float attackRange;
	NavMeshAgent agent;

	enum State
	{
		Idle,
		Chase,
		Attack,
		Damage,
		Dead
	};
	State state;

	void Start()
	{
		animator.GetComponentInChildren<Animator>();
		agent = GetComponentInChildren<NavMeshAgent>();
	}

	void Update()
	{
		switch(state)
		{
		case State.Idle: 
			UpdateIdle();
			break;
		case State.Chase:
			UpdateChase();
			break;
		case State.Attack:
			UpdateAttack();
			break;
		case State.Damage:
			UpdateDamage();
			break;
		case State.Dead:
			UpdateDead();
			break;

		}

	}

	//This s the shere around the zombies "trigger zone" where the zombie will sense you
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			//Set target to the player so the zombie has a target.
			target = other.gameObject;
		}

	}
	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			//stop going after the player because he has exited our target zone
			target = null;
		}

	}

	void UpdateIdle()
	{
		//if the target is set to a player go into chase mode after the player. 
		if(target != null)
		{
			state = State.Chase;
			animator.SetBool("TargetSpottedBool", true);
		}
	}
	void UpdateChase()
	{
		if(target == null)
		{
			state = State.Idle;
			animator.SetBool("TargetSpottedBool", false);
		}
		else
		{
			float distance = Vector3.Distance(transform.position, target.transform.position);
			if(distance <= attackRange)
			{
				state = State.Attack;
				animator.SetBool("TargetSpottedBool", false);
				animator.SetTrigger("AttackTrg");
			}
			else
			{
				agent.SetDestination(target.transform.position);
			}
		}
	}

	void UpdateAttack()
	{
		AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
		if(info.IsName("Main.Idle"))
		{
			state = State.Idle;
		}
	}

	void UpdateDamage()
	{


	}

	void UpdateDead()
	{


	}
		
}
