using UnityEngine;
using System.Collections;

public class GridManager : MonoBehaviour {

	// Public Variables
	[SerializeField]
	private Vector2 gridDimension = new Vector2(10f, 10f);
	public Vector2 GridDimension {
		get { return gridDimension; }
	}

	[SerializeField]
	private float gridSpacing = 0.3f;
	public float GridSpacing {
		get { return gridSpacing; }
	}

	[SerializeField]
	private GameObject gridPrefab;

	[SerializeField]
	private GameObject wallPrefab;

	// Private Variables
	private Transform[] gridList;
	public Transform[] GridList {
		get { return gridList; }
	}

	// Static Variables
	public static GridManager sharedInstance;

	private void Awake() {
		sharedInstance = this;
	}

	private void OnEnable() {
		float xOffset = gridDimension.x * 0.5f;
		float yOffset = gridDimension.y * 0.5f;

		int gridTotal = (int)gridDimension.x * (int)gridDimension.y;
		gridList = new Transform[gridTotal];

		int gridCount = 0;
		for (int y = 0; y < gridDimension.y; y++) {
			for (int x = 0; x < gridDimension.x; x++) {
				GameObject grid = (GameObject)Instantiate(gridPrefab);
				grid.name = "Grid " + (gridCount + 1) + " [" + x + ", " + y + "]";
				grid.transform.position = new Vector3((x - xOffset) * gridSpacing, (yOffset -  y) * gridSpacing, 0f);
				grid.transform.parent = transform;
				gridList[gridCount] = grid.transform;

				Grid gridScript = grid.GetComponent<Grid>();
				gridScript.GridID = gridCount;
				gridScript.GridLocation = new Vector2((int)x, (int)y);

				gridCount++;
			}
		}

		GameObject wallBound = new GameObject("Wall Bound");

		// Create Wall
		for (int i = 0; i < gridList.Length; i++) {
			if (i % 10 == 0) {
				GameObject wall = (GameObject)Instantiate(wallPrefab);
				wall.name = "Wall";
				wall.transform.position = gridList[i].transform.position - (Vector3.right * gridSpacing);
				wall.transform.parent = wallBound.transform;

				wall = (GameObject)Instantiate(wallPrefab);
				wall.name = "Wall";
				wall.transform.position = gridList[i].transform.position + (Vector3.right * gridSpacing) * 10f;
				wall.transform.parent = wallBound.transform;
			}
			if (i >= 90) {
				GameObject wall = (GameObject)Instantiate(wallPrefab);
				wall.name = "Wall";
				wall.transform.position = gridList[i].transform.position - (Vector3.up * gridSpacing);
				wall.transform.parent = wallBound.transform;

				wall = (GameObject)Instantiate(wallPrefab);
				wall.name = "Wall";
				wall.transform.position = gridList[i].transform.position + (Vector3.up * gridSpacing) * 10f;
				wall.transform.parent = wallBound.transform;
			}
		}
	}

	public Transform GetGridByLocation(Vector2 location) {
		for (int i = 0; i < gridList.Length; i++) {
			Grid grid = gridList[i].GetComponent<Grid>();
			if (grid != null && grid.GridLocation == location) {
				return grid.ThisT;
			}
		}

		return null;
	}

	public Transform GetGridByID(int id) {
		for (int i = 0; i < gridList.Length; i++) {
			Grid grid = gridList[i].GetComponent<Grid>();
			if (grid != null && grid.GridID == id) {
				return grid.ThisT;
			}
		}

		return null;
	}

	public Vector2 GetGridLocation(int id) {
		for (int i = 0; i < gridList.Length; i++) {
			Grid grid = gridList[i].GetComponent<Grid>();
			if (grid != null && grid.GridID == id) {
				return grid.GridLocation;
			}
		}

		return new Vector2(-1f, -1f);
	}

	//public void GetGridAddress(Transform root, ref int i, ref int j) {
	//    for (int y = 0; y < gridDimension.y; y++) {
	//        for (int x = 0; x < gridDimension.x; x++) {
	//            if (root == gridHolder[x, y]) {
	//                i = x;
	//                j = y;
	//            }
	//        }
	//    }
	//}

	//public Transform GetGrid(int i, int j) {
	//    for (int y = 0; y < gridDimension.y; y++) {
	//        for (int x = 0; x < gridDimension.x; x++) {
	//            if (x == i && y == j) {
	//                return gridHolder[x, y];
	//            }
	//        }
	//    }
	//    return null;
	//}
}