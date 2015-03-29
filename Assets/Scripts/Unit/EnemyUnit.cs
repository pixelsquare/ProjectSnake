using UnityEngine;
using System.Collections;
using GameID;

public class EnemyUnit : Unit {

	// Public Variables

	// Private Variables

	// Static Variables

	protected override void Start() {
		base.Start();
		UnitType = TypeID.ENEMY;
	}
}