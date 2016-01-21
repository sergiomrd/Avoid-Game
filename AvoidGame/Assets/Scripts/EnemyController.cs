using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public enum BehaviorType {Normal, Faster, Rocket};

	public BehaviorType enemyBehavior;

	public float speed = 3;
	public float acceleration = 4;
	private float runPosition;


	private bool inPositionStart;
	private bool inPositionEnd;
	private bool animationDone;
	private bool onCorrutineStart;

	Vector3 movementVector, spawnVector;

	void Start () {
	
		movementVector = new Vector3(0,0f,-1f);
		spawnVector = new Vector3(0,1f,0f);
		runPosition = 0.5f;
		inPositionStart = false;
		inPositionEnd = false;
		animationDone = false;
		onCorrutineStart = false;

	}

	void Awake()
	{
		StartingMove(enemyBehavior);
	}

	void Update () {

		Move();

	}
		
	void Move()
	{
		//SpawnMovement Up
		if(!inPositionStart)
		{
			if(transform.position.y < runPosition)
			{
				Vector3 movement = spawnVector * speed * Time.deltaTime;
				transform.position += movement;
			}
			else
			{
				inPositionStart = true;
			}
		}

		//Behavior at Run
		if(inPositionStart && !inPositionEnd)
		{
			if(transform.position.z <= -6)
			{
				inPositionEnd = true;
			}
			else
			{
				DoBehaviorAtRun();
			}
		}

		//End Movement
		if(inPositionEnd)
		{
			Vector3 movement = -spawnVector * speed * Time.deltaTime;
			transform.position += movement;	
		}
			

			
	}

	void DoBehaviorAtRun()
	{
		Vector3 movement;

		switch(enemyBehavior)
		{
		case BehaviorType.Normal:

			movement = movementVector * (speed * acceleration) * Time.deltaTime;
			transform.position += movement;	

			break;
		case BehaviorType.Faster:
			
			movement = movementVector * (speed * acceleration) * Time.deltaTime;
			transform.position += movement;	

			break;
		case BehaviorType.Rocket:

			if(!animationDone)
			{

				if(!onCorrutineStart)
				{
					StartCoroutine(RocketAnimation());
				}

			}
			else
			{
				movement = movementVector * (speed * acceleration) * Time.deltaTime;
				transform.position += movement;
			}

			break;
		
		}
	}

	IEnumerator RocketAnimation()
	{
		onCorrutineStart = true;

		while(transform.localScale.x < 0.5 && transform.localScale.y < 0.5 && transform.localScale.z < 0.5)
		{

			transform.localScale += new Vector3(0.01f,0.01f,0.01f);

			yield return new WaitForSeconds(0.01f);

		}
				
		while(transform.localScale.x > 0.2 && transform.localScale.y > 0.2 && transform.localScale.z > 0.2)
		{

			transform.localScale -= new Vector3(0.01f,0.01f,0.01f);

			yield return new WaitForSeconds(0.01f);

		}

		yield return new WaitForSeconds(0.3f);

		animationDone = true;
		onCorrutineStart = false;
	}

	void StartingMove(BehaviorType enemyBehavior)
	{
		switch(enemyBehavior)
		{
		case BehaviorType.Normal:

			speed = 3;
			acceleration = 1;

			break;

		case BehaviorType.Faster:

			speed = 4;
			acceleration = 1;
			
			break;

		case BehaviorType.Rocket:

			speed = 3;
			acceleration = 3;

			break;

		}
	}

	void SpawnMovement()
	{
		if(transform.position.y >= 0.5)
		{
			inPositionStart = true;
		}
		else
		{
			Vector3 movement = spawnVector * speed * Time.deltaTime;
			transform.position += movement;
		}

	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Boundary"))
		{
			Destroy(gameObject);
		}
	}
}
