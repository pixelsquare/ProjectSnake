using UnityEngine;
using System.Collections;
using GameID;

public class Unit : BaseUnit {

	// Public Variables
	[SerializeField]
	private float unitSpeed = 1f;
	public float UnitSpeed {
		get { return unitSpeed; }
	}

	[SerializeField]
	private DirectionID unitDirection;
	public DirectionID UnitDirection {
		get { return unitDirection; }
	}

	// Private Variables
	private Transform unitAttachedTo;
	public Transform UnitAttachedTo {
		get { return unitAttachedTo; }
		set { 
			unitAttachedTo = value;
			if (unitAttachedTo != null) {
				unitAttachedToInfo = unitAttachedTo.GetComponent<AllyUnit>();
			}
		}
	}

	private AllyUnit unitAttachedToInfo;
	public AllyUnit UnitAttachedToInfo {
		get { return unitAttachedToInfo; }
	}

	private TypeID unitType;
	public TypeID UnitType {
		get { return unitType; }
		set { unitType = value; }
	}

	private StateID unitState;
	public StateID UnitState {
		get { return unitState; }
		set { unitState = value; }
	}

	private Vector3 unitOldMoveDirection;
	public Vector3 UnitOldMoveDirection {
		get { return unitOldMoveDirection; }
	}

	private Vector3 unitMoveDirection;
	public Vector3 UnitMoveDirection {
		get { return unitMoveDirection; }
	}

	private int unitDirectionMultiplier = 1;
	public int UnitDirectionMultiplier {
		get { return unitDirectionMultiplier; }
	}

	private Vector2 unitGridLocation;
	public Vector2 UnitGridLocation {
		get { return unitGridLocation; }
		set {
			Vector2 tmpValue = value;
			tmpValue.x = Mathf.RoundToInt(tmpValue.x);
			tmpValue.y = Mathf.RoundToInt(tmpValue.y);
			unitGridLocation = tmpValue;

			if (tmpValue.x > 0 && tmpValue.y > 0) {
				transform.position = GridManager.sharedInstance.GetGridByLocation(tmpValue).position;
			}
			
		}
	}

	private DirectionID unitOldDirection;
	public DirectionID UnitOldDirection {
		get { return unitOldDirection; }
	}

	private Transform targetGrid;
	private Transform targetUnit;

	private float rayOffset;
	private float distanceToGrid;

	private float totalDistanceToGrid;
	private float midwayDistanceToGrid;

	private const float MIDWAY_DISTANCE_THRESHOLD = 0.5f;
	private const float MIDWAY_MIN_THRESHOLD = 0.1f;

	// Static Variables

	protected override void Start() {
		base.Start();
		rayOffset = GridManager.sharedInstance.GridSpacing * 0.41f;
		unitMoveDirection = (unitDirection == DirectionID.HORIZONTAL) ? Vector3.right : Vector3.up;
		unitMoveDirection *= unitDirectionMultiplier;

		UpdateGridPosition();
		targetUnit = GetTargetUnit();
	}

	private void Update() {
		if (unitState == StateID.MOVING) {
			// Player Controls
			if (unitOldDirection == DirectionID.HORIZONTAL) {
				if (Input.GetKeyDown(KeyCode.UpArrow)) {
					unitDirectionMultiplier = 1;
					unitMoveDirection = Vector3.up * unitDirectionMultiplier;
					unitDirection = DirectionID.VERTICAL;
				}

				if (Input.GetKeyDown(KeyCode.DownArrow)) {
					unitDirectionMultiplier = -1;
					unitMoveDirection = Vector3.up * unitDirectionMultiplier;
					unitDirection = DirectionID.VERTICAL;
				}
			}

			if (unitOldDirection == DirectionID.VERTICAL) {
				if (Input.GetKeyDown(KeyCode.RightArrow)) {
					unitDirectionMultiplier = 1;
					unitMoveDirection = Vector3.right * unitDirectionMultiplier;
					unitDirection = DirectionID.HORIZONTAL;
				}

				if (Input.GetKeyDown(KeyCode.LeftArrow)) {
					unitDirectionMultiplier = -1;
					unitMoveDirection = Vector3.right * unitDirectionMultiplier;
					unitDirection = DirectionID.HORIZONTAL;
				}
			}

			// Check for Units
			if (targetUnit != null && targetUnit.gameObject.layer == LayerManager.UnitLayer) {
				Unit unit = targetUnit.GetComponent<Unit>();
				if (unit != null) {
					if (unit.unitType == TypeID.ALLY) {

					}

					if (unitType == TypeID.ENEMY) {

					}
				}
			}
		}

		if (targetGrid != null) {
			// Determine the distance to the next grid
			distanceToGrid = Vector3.Distance(transform.position, targetGrid.position);

			if (distanceToGrid > 0f) {
				transform.position = Vector3.MoveTowards(transform.position, targetGrid.position, unitSpeed * Time.deltaTime);

				// Halfway to the grid
				if (distanceToGrid > (midwayDistanceToGrid - (midwayDistanceToGrid * MIDWAY_MIN_THRESHOLD)) && distanceToGrid < midwayDistanceToGrid) {
					if (unitState == StateID.MOVING) {
						unitOldMoveDirection = unitMoveDirection;
					}
					else if (unitState == StateID.FOLLOWING) {
						if (unitAttachedToInfo != null) {
							if (unitAttachedToInfo.UnitOldDirection != unitDirection) {
								unitDirection = unitAttachedToInfo.UnitOldDirection;
								unitDirectionMultiplier = unitAttachedToInfo.UnitDirectionMultiplier;
								unitMoveDirection = unitAttachedToInfo.UnitOldMoveDirection;
							}
						}
					}
				}

				Debug.DrawLine(transform.position, targetGrid.position, Color.blue);
			}
			else {
				UpdateGridPosition();
				targetUnit = GetTargetUnit();
				unitOldDirection = unitDirection;
			}
		}
		else {
			UpdateGridPosition();
			targetUnit = GetTargetUnit();
		}

		Debug.DrawRay(transform.position + (unitMoveDirection * rayOffset), unitMoveDirection * rayOffset, Color.red);
	}

	private void UpdateGridPosition() {
		targetGrid = GetTargetGrid();
		if (targetGrid != null) {
			totalDistanceToGrid = Vector3.Distance(transform.position, targetGrid.position);
			midwayDistanceToGrid = totalDistanceToGrid * MIDWAY_DISTANCE_THRESHOLD;

			Grid grid = targetGrid.GetComponent<Grid>();
			if (grid != null) {
				Vector2 tmpLocation = grid.GridLocation;
				if (unitDirection == DirectionID.HORIZONTAL) {
					tmpLocation.x += -Mathf.Sign(unitDirectionMultiplier);
				}
				if (unitDirection == DirectionID.VERTICAL) {
					tmpLocation.y += Mathf.Sign(unitDirectionMultiplier);
				}
				unitGridLocation = tmpLocation;
			}
		}
	}

	private Transform GetTargetGrid() {
		int gridLayers = 1 << LayerManager.GridLayer;
		RaycastHit2D gridHit = Physics2D.Raycast(transform.position + (unitMoveDirection * rayOffset), unitMoveDirection, rayOffset, gridLayers);
		return gridHit.transform;
	}

	private Transform GetTargetUnit() {
		int unitLayers = 1 << LayerManager.UnitLayer;
		RaycastHit2D unitHit = Physics2D.Raycast(transform.position + (unitMoveDirection * rayOffset), unitMoveDirection, rayOffset, unitLayers);
		return unitHit.transform;
	}
}