using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameID;

/// <summary>
/// TODO: 
/// 1. Combat Log (Console/GUI)
/// OK 2. Separate Attack for Unit Ally and Unit Enemy for attack speed property
/// OK 3. Test out a new Script that will Pool number popout
/// </summary>

public class GameManager : MonoBehaviour {

	// Public Variables
	[SerializeField]
	private int unitTrailLength = 5;

	[SerializeField]
	private int unitStartGridIndx = 85; 

	// Private Variables
	private List<GameObject> unitTrailBody;
	public List<GameObject> UnitTrailBody {
		get { return unitTrailBody; }
		set { unitTrailBody = value; }
	}

	private GameObject unitTrailHead;
	public GameObject UnitTrailHead {
		get { return unitTrailHead; }
		set { unitTrailHead = value; }
	}

	// Static Variables
	public static GameManager sharedInstance;

	private void Awake() {
		sharedInstance = this;
	}

	private void Start() {
		unitTrailBody = new List<GameObject>();
		unitTrailHead = ObjectPoolManager.sharedInstance.GetPooledObject(ObjectID.ALLY_UNIT);
		if (unitTrailHead != null) {
			AllyUnit unitHead = unitTrailHead.GetComponent<AllyUnit>();
			unitHead.UnitState = StateID.MOVING;
			unitHead.UnitGridLocation = GridManager.sharedInstance.GetGridLocation(unitStartGridIndx);

			unitTrailHead.name = "Trail Head";
			//unitTrailHead.transform.position = GridManager.sharedInstance.GetGrid(unitStartGridIndx).position;
			//unitTrailHead.layer = LayerManager.TrailHeadLayer;
			unitTrailHead.SetActive(true);
			unitTrailBody.Add(unitTrailHead);
		}

		//if (unitTrailLength > 0) {
		//    for (int i = 0; i < unitTrailLength; i++) {
		//        UnitUtilities.AddNewTrail();
		//    }
		//}

		//if (unitTrailBody.Count > 1) {
		//    AllyUnit headUnit = unitTrailHead.GetComponent<AllyUnit>();
		//    headUnit.UnitAttachedTo = unitTrailBody[1].transform;
		//}

		//for (int i = 0; i < 3; i++) {
		//    GameObject enemyTest = ObjectPoolManager.sharedInstance.GetPooledObject(ObjectID.ENEMY_UNIT);
		//    int randomPos = Random.Range(0, GridManager.sharedInstance.GridList.Length);
		//    enemyTest.transform.position = GridManager.sharedInstance.GridList[randomPos].position;
		//    enemyTest.SetActive(true);
		//}

		//for (int i = 0; i < 3; i++) {
		//    GameObject allyTest = ObjectPoolManager.sharedInstance.GetPooledObject(ObjectID.ALLY_UNIT);
		//    int randomPos = Random.Range(0, GridManager.sharedInstance.GridList.Length);
		//    allyTest.transform.position = GridManager.sharedInstance.GridList[randomPos].position;
		//    allyTest.SetActive(true);
		//}
	}

	//private void Update() {
		//if (Input.GetKeyDown(KeyCode.Q)) {
		//    UnitUtilities.SwapTrailElements();
		//    //RemoveTrailHead();
		//}
	//}

	public int GetTrailBodyLength() {
		return unitTrailBody.Count;
	}
}