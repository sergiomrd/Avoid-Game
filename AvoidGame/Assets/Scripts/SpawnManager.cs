using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour {

	public GameObject[] arrayEnemies = new GameObject[3];

	private int randomEnemy;
	private float randomXPosition;
	private float minBound;
	private float maxBound;

	private float timer;

	void Awake () {

		minBound = -1.47f;
		maxBound = 2;
		timer = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(timer >= 2.0f)
		{
			SpawnEnemy();
			timer = 0;
		}


	}

	void SpawnEnemy()
	{
		randomEnemy = Random.Range(0, arrayEnemies.Length);
		randomXPosition = Random.Range(minBound,maxBound);

		Vector3 spawnPosition = new Vector3(randomXPosition, -10f, 5.5f);

		Instantiate(arrayEnemies[randomEnemy], spawnPosition, Quaternion.identity);

	}
}
