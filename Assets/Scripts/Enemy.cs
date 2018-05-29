using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] private float speed = 5f;
	private GameObject	target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(target != null){
			transform.rotation = Quaternion.LookRotation(target.transform.position, transform.position);
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		}
	}	
}
