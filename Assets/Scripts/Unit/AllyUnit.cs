using UnityEngine;
using System.Collections;
using GameID;

public class AllyUnit : Unit {

	// Public Variables

	// Private Variables
	private UnitInformation unitInfo;
	public UnitInformation UnitInfo {
		get { return unitInfo; }
		set { unitInfo = value; }
	}

	// Static Variables

	protected override void Start() {
		base.Start();
		UnitType = TypeID.ALLY;
	}
}