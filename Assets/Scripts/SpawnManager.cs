using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField] private float timeToSpawn = 2;
	private float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		
		if(time >= timeToSpawn){
			time = 0;
			ObjectPool.instance.reuseObjects(ObjectPool.instance.EnemyPrefab, this.transform);
		}
	}
}
