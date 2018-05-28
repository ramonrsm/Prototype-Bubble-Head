using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	[Header("Player")]
	[SerializeField] private float speedRotation = 3.5f;

	[Header("Gun")]
	public Transform 	spawnBullets;
	public GameObject	bulletPrefab;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if(Input.GetMouseButton(0)){
			
			#region Rotação Player

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit raycastHit;

			if(Physics.Raycast(ray, out raycastHit) && raycastHit.collider != null){

				if(raycastHit.transform.tag.Equals("Enemy")){

					Transform target    = raycastHit.transform;
					Quaternion rotation = Quaternion.LookRotation(target.position, transform.position);
					transform.rotation  = Quaternion.Slerp(transform.rotation, rotation, speedRotation * Time.deltaTime);
				}
			}

			#endregion		
		}

        // Atirar
        if (Input.GetButtonDown("Jump"))
        {			
            ObjectPool.instance.reuseObjects(bulletPrefab, spawnBullets);
        }
    }
}
