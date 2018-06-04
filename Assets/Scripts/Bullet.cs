using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private float	speed = 6f;
	[SerializeField] private float  lifeTime = 3f;
	private float timer = 0;
	private Vector3	previousFrame;

	// Use this for initialization
	void Start () {
		//previousFrame = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		/*#region Tempo de vida da Bala
		timer += Time.deltaTime;

		if(timer > lifeTime){
			transform.gameObject.SetActive(false);
			timer = 0;
		}
		#endregion*/

		// Movimentação da bala
		transform.Translate((Vector3.forward * speed) * Time.deltaTime, Space.Self);

		/*Vector3 pos = (transform.position - previousFrame);
		pos.Normalize();
		Ray ray = new Ray(previousFrame, pos);
		RaycastHit hit;
		Debug.DrawLine(previousFrame, transform.position, Color.red);

		if(Physics.Raycast(ray, out hit, (transform.position - previousFrame).magnitude)){
			if(hit.collider.tag.Equals("Enemy")){
				hit.transform.gameObject.SetActive(false);
				gameObject.SetActive(false);
			}
		}*/
	}
	
	void LateUpdate(){
		//previousFrame = transform.position;
	}
}
