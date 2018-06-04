using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {

	[SerializeField]
	private List<Pool> listaPool;
	
	[System.Serializable]
	public class Pool{
		public GameObject prefab;
		public int 		  amount;
	}

	#region Singleton

	private static ObjectPoolManager _instance;

	public static ObjectPoolManager instance
	{		
		get{
			if(_instance == null){
				_instance = FindObjectOfType<ObjectPoolManager>();
			}				
			return _instance;
		}		
	}

	#endregion

	public Dictionary <int, Queue<GameObject>> poolDictionary;	

	/*----------------------------------------------------------------------------------------------------- */

	void Awake(){
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

	public GameObject reuseObjects(GameObject obj, Transform transformGO){

		int key = obj.GetInstanceID();

		if(poolDictionary.ContainsKey(key)){

			GameObject reuseObject = poolDictionary[key].Dequeue();

			poolDictionary[key].Enqueue(reuseObject);

			reuseObject.SetActive(false);

			if(!reuseObject.activeInHierarchy && reuseObject != null){

				reuseObject.transform.position = transformGO.position;
				reuseObject.transform.rotation = transformGO.rotation;
				reuseObject.SetActive(true);
				return reuseObject;
			}
		}
		return null;
	}

	// Use this for initialization
	void Start () {
		
		foreach(Pool pool in listaPool){
			createObjects(pool.amount, pool.prefab);
		}
	}
}
