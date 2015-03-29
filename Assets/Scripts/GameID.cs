using UnityEngine;
using System.Collections;

namespace GameID {
	public enum StateID {
		STATIC = 0,
		MOVING = 1,
		FOLLOWING = 2,
		COMBAT = 3,
		ATTACHING = 4
	}

	public enum DirectionID {
		HORIZONTAL = 0,
		VERTICAL = 1
	}

	public enum TypeID {
		NONE = 0,
		ENEMY = 1,
		ALLY = 2
	}

	public enum TrailTypeID {
		NONE = 0,
		HEAD = 1,
		BODY = 2
	}

	public enum ClassTypeID {
		NONE = 0,
		WARRIOR = 1,
		ARCHER = 2,
		MAGE = 3
	}

	public enum RaceTypeID {
		NONE = 0,
		RED = 1,
		GREEN = 2,
		BLUE = 3
	}

	public enum ObjectID {
		NONE = 0,
		ENEMY_UNIT = 1,
		ALLY_UNIT = 2,
		PARTICLE_UNIT_ATTACH_1 = 3,
		PARTICLE_UNIT_ATTACH_2 = 4,
		PARTICLE_UNIT_HURT = 5,
		PARTICLE_NUMBER_POPUP = 6,
		SP_NUMBER_POPUP = 7,
		SP_ANIMATED_NUMBER_POPUP = 8
	}
}