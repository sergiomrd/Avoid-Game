using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public enum BehaviorType {Normal, Faster};

	public BehaviorType enemyBehavior;

	public float speed = 3;

	private bool inPositionStart = false;
	private bool inPositionEnd = false;

	Vector3 movementVector, spawnVector;

	void Start () {
	
		movementVector = new Vector3(0,0f,-1f);
		spawnVector = new Vector3(0,1f,0f);

	}

	void Awake()
	{
		ChooseBehavior();
	}

	void Update () {
	
		if(!inPositionStart)
		{
			SpawnMovement();
		}
		else if(transform.position.z <= -6)
		{
			EndMovement();
		}
		else
		{
			Vector3 movement = movementVector * speed * Time.deltaTime;
			transform.position += movement;
		}
	}

	void ChooseBehavior()
	{
		switch(enemyBehavior)
		{
		case BehaviorType.Normal:

			speed = 3;

			break;

		case BehaviorType.Faster:

			speed = 5;

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

	void EndMovement()
	{
		Vector3 movement = -spawnVector * speed * Time.deltaTime;
		transform.position += movement;
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Boundary"))
		{
			gameObject.SetActive(false);
		}
	}
}
