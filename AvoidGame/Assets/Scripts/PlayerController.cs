using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	public float acceleration = 0.2f;


	Vector3 movementVector;

	void Awake()
	{
		movementVector = new Vector3(1f,0,0);
	}

	void Update () {


		Vector3 movement = movementVector * Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		transform.position += movement;

		if(transform.position.x < -1.47f)
		{
			transform.position = new Vector3 (-1.47f, transform.position.y, transform.position.z);
		}
		else if (transform.position.x > 2f)
		{
			transform.position = new Vector3 (2f, transform.position.y, transform.position.z);
		}
	
	}

	void MoveLeft()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		{
			Debug.Log("Game Over");
		}
	}
}
