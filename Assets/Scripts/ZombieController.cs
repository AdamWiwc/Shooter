using UnityEngine;
using System.Collections;

//Script is attatched to all zombies

public class ZombieController : MonoBehaviour 
{

	Animator animator;
	GameObject target;
	public float attackRange;
	public float attackDamage;
	NavMeshAgent agent;
	bool reset = true;
	float currentHealth;

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
		animator = GetComponentInChildren<Animator>();
		agent = GetComponent<NavMeshAgent>();
		currentHealth = 100;
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
			UpdateDamage(currentHealth);
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
		else
		{
			agent.Stop();
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
				animator.SetTrigger("AttackTrg");
				agent.Stop();
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
			animator.SetBool("TargetSpottedBool", false);
			state = State.Idle;
		}

	}

	void OnAttackEvent()
	{
		if(target != null)
		{
			float distance = Vector3.Distance(transform.position, target.transform.position);
			if(distance <= attackRange)
			{
				//this basically sends a message to the game object target and says 'hey oif you have a script called TakeDamage, Run it! if not ignore me!'
				target.SendMessage("TakeDamage", attackDamage); 
				DamageHUD.Instance.OnPlayerHit();
				
			}
			
		}
	}

	void UpdateDamage(float health)
	{
		state = State.Damage;
		currentHealth = health;

		if(reset) //this is to make the zombie only play the hurt animation once. 
		{
			agent.Stop();
			animator.SetTrigger("HurtTrg");
			reset = false;
		}

		if(currentHealth <= 0)
		{
			animator.SetBool("IsAliveBool", false);
			animator.SetTrigger("DieTrg");
			state = State.Dead;
			reset = true;				
		}
		else
		{

			AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
			animator.SetBool("TargetSpottedBool", false);
			animator.SetBool("IsAliveBool", true);

			if(info.IsName("Main.Idle"))
			{
				reset = true;
				state = State.Idle;
			}
		}
	}

	void UpdateDead()
	{
		agent.Stop();
		if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
		{
			Destroy(gameObject);
		}
		
	}
	
		
}
