using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private float	speed = 3.5f;
	[SerializeField] private float  lifeTime = 3f;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer > lifeTime){
			transform.gameObject.SetActive(false);
			timer = 0;
		}

		transform.Translate((Vector3.forward * speed) * Time.deltaTime, Space.World);
	}
}
