using UnityEngine;
using System.Collections;
using GameID;

[System.Serializable]
public class UnitInformation  {

	// Public Variables
	[SerializeField]
	private string unitName;
	public string UnitName {
		get { return unitName; }
		set { unitName = value; }
	}

	[SerializeField]
	private Sprite unitAvatar;
	public Sprite UnitAvatar {
		get { return unitAvatar; }
		set { unitAvatar = value; }
	}

	[SerializeField]
	private int unitHp;
	public int UnitHp {
		get { return unitHp; }
		set { unitHp = Mathf.Clamp(value, 0, 9999); }
	}

	[SerializeField]
	private int unitDamage;
	public int UnitDamage {
		get { return unitDamage; }
		set { unitDamage = value; }
	}

	[SerializeField]
	private int unitDefense;
	public int UnitDefense {
		get { return unitDefense; }
		set { unitDefense = value; }
	}

	[SerializeField]
	private float unitAttackSpeed;
	public float UnitAttackSpeed {
		get { return unitAttackSpeed; }
		set { unitAttackSpeed = value; }
	}

	[SerializeField]
	private int unitDamageTaken;
	public int UnitDamageTaken {
		get { return unitDamageTaken; }
		set { unitDamageTaken = value; }
	}

	[SerializeField]
	private ClassTypeID unitClassType;
	public ClassTypeID UnitClassType {
		get { return unitClassType; }
		set { unitClassType = value; }
	}

	[SerializeField]
	private RaceTypeID unitColorType;
	public RaceTypeID UnitColorType {
		get { return unitColorType; }
		set { unitColorType = value; }
	}

	// Private Variables

	// Static Variables

	public UnitInformation() {
		unitName = string.Empty;
		unitHp = 0;
		unitDamage = 0;
		unitDefense = 0;
		unitAttackSpeed = 0f;
	}

	public UnitInformation(string name) {
		unitName = name;
		unitHp = 0;
		unitDamage = 0;
		unitDefense = 0;
		unitAttackSpeed = 0f;
	}
}