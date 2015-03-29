using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameID;

public class ObjectPoolManager : MonoBehaviour {

	// Public Variables
	[SerializeField]
	private PooledObject[] pooledObject;

	// Private Variables

	// Static Variables
	public static ObjectPoolManager sharedInstance;

	private void Awake() {
		sharedInstance = this;
	}

	private void OnEnable() {
		for (int i = 0; i < pooledObject.Length; i++) {
			pooledObject[i].PopulateObject();
			pooledObject[i].ObjParent.parent = transform;
		}
	}

	private void LateUpdate() {
		for (int i = 0; i < pooledObject.Length; i++) {
			if (pooledObject[i].IsParticle) {
				pooledObject[i].UpdateParticle();
			}
		}
	}

	public GameObject GetPooledObject(ObjectID type) {
		for (int i = 0; i < pooledObject.Length; i++) {
			if (pooledObject[i].ObjectID == type) {
				return pooledObject[i].GetObject();
			}
		}

		return null;
	}
}

[System.Serializable]
public class PooledObject {
	[SerializeField]
	private string objectName;
	public string ObjectName {
		get { return objectName; }
	}

	[SerializeField]
	private GameObject objectPrefab;
	public GameObject ObjectPrefab {
		get { return objectPrefab; }
	}

	[SerializeField]
	private ObjectID objectID;
	public ObjectID ObjectID {
		get { return objectID; }
	}

	[SerializeField]
	private int pooledAmount = 1;
	public int PooledAmount {
		get { return pooledAmount; }
	}

	[SerializeField]
	private bool isParticle;
	public bool IsParticle {
		get { return isParticle; }
	}

	[SerializeField]
	private bool canGrow;
	public bool CanGrow {
		get { return canGrow; }
	}

	private List<GameObject> objectHolder;
	public List<GameObject> ObjectHolder {
		get { return objectHolder; }
	}

	private GameObject objParent;
	public Transform ObjParent {
		get { return objParent.transform; }
	}

	public void PopulateObject() {
		objParent = new GameObject(objectName + " Parent");
		objectHolder = new List<GameObject>();

		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)UnityEngine.Object.Instantiate(objectPrefab);
			obj.name = objectPrefab.name;
			obj.transform.parent = objParent.transform;
			obj.SetActive(false);
			objectHolder.Add(obj);
		}
	}

	public void UpdateParticle() {
		for (int i = 0; i < objectHolder.Count; i++) {
			ParticleSystem particle = objectHolder[i].GetComponent<ParticleSystem>();
			if (!particle.IsAlive()) {
				objectHolder[i].SetActive(false);
			}
		}
	}

	public GameObject GetObject() {
		for (int i = 0; i < objectHolder.Count; i++) {
			if (!objectHolder[i].gameObject.activeInHierarchy) {
				return objectHolder[i];
			}
		}

		if (canGrow) {
			GameObject obj = (GameObject)UnityEngine.Object.Instantiate(objectPrefab);
			obj.name = objectPrefab.name;
			obj.transform.parent = objParent.transform;
			obj.SetActive(false);
			objectHolder.Add(obj);
			return obj;
		}

		return null;
	}
}