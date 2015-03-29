using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	// Public Variables

	// Private Variables
	private int gridID;
	public int GridID {
		get { return gridID; }
		set { gridID = value; }
	}

	private Vector2 gridLocation;
	public Vector2 GridLocation {
		get { return gridLocation; }
		set {
			Vector2 tmpValue = value;
			tmpValue.x = Mathf.RoundToInt(tmpValue.x);
			tmpValue.y = Mathf.RoundToInt(tmpValue.y);
			gridLocation = tmpValue;
		}
	}

	private Transform thisT;
	public Transform ThisT {
		get { return thisT; }
	}

	private GameObject thisG;
	public GameObject ThisG {
		get { return thisG; }
	}

	// Static Variables

	private void Awake() {
		gridID = 0;
		gridLocation = Vector2.zero;
		thisT = transform;
		thisG = gameObject;
	}
}