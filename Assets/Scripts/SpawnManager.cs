using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField] private float	timeToSpawn = 3f;
	private float	time;

	void Start()
	{
		time = 0;
	}

	void Update()
	{
		time += Time.deltaTime;		
	}


	public void SpawnPosition(float timeToSpawn, GameObject gameObejct,Transform transformGO){
		gameObejct.transform.position = transformGO.position;
		gameObejct.transform.rotation = transformGO.rotation;
	}

	public void SpawnPosition(GameObject gameObejct,Transform transformGO){
		gameObejct.transform.position = transformGO.position;
		gameObejct.transform.rotation = transformGO.rotation;
	}
}
