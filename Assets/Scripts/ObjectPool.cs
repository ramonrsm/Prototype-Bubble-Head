using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	[Header("Bullets")]
	public GameObject bulletPrefab;
	public int 		  amountBullets = 5;
	public Dictionary <int, Queue<GameObject>> poolDictionary;

	#region Padrao Singleton

	private static ObjectPool _instance;

	public static ObjectPool instance
	{		
		get{
			if(_instance == null){
				_instance = FindObjectOfType<ObjectPool>();
			}				
			return _instance;
		}		
	}

	#endregion

	/*----------------------------------------------------------------------------------------------------- */

	void Awake()
	{
		this.poolDictionary = new Dictionary<int, Queue<GameObject>>();
	}

	public void createObjects(int amount, GameObject prefab){

		int key = prefab.GetInstanceID();

		if(!poolDictionary.ContainsKey(key)){

			poolDictionary.Add(key, new Queue<GameObject>());

			for(int i = 0; i < amount; i++){

				GameObject obj = Instantiate(prefab) as GameObject;
				obj.SetActive(false);

				poolDictionary[key].Enqueue(obj);
			}
		}
	}

	public GameObject reuseObjects(GameObject obj, Vector3 position, Quaternion rotation){

		int key = obj.GetInstanceID();

		if(poolDictionary.ContainsKey(key)){

			GameObject reuseObject = poolDictionary[key].Dequeue();
			poolDictionary[key].Enqueue(reuseObject);

			if(!reuseObject.activeInHierarchy){
				reuseObject.SetActive(true);
				reuseObject.transform.position = position;
				reuseObject.transform.rotation = rotation;
				return reuseObject;
			}
		}

		return null;
	}

	// Use this for initialization
	void Start () {

		// Instanciar Balas
		createObjects(amountBullets, bulletPrefab);
	}
	
	// Update is called once per frame
	void Update () {		
		
	}

}
