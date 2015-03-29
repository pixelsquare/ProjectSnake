using UnityEngine;
using System.Collections;
using GameID;

public static class UnitUtilities  {

	//public static void AddNewTrail() {
	//    GameObject trailBody = ObjectPoolManager.sharedInstance.GetPooledObject(ObjectID.ALLY_UNIT);

	//    if (trailBody != null) {
	//        int trailBodyLength = GameManager.sharedInstance.GetTrailBodyLength();
	//        GameObject headNode = GameManager.sharedInstance.UnitTrailBody[trailBodyLength - 1];
	//        AllyUnit unitHeadNode = headNode.GetComponent<AllyUnit>();

	//        AllyUnit unitTrail = trailBody.GetComponent<AllyUnit>();
	//        //unitTrail.Clone(unitHeadNode);
	//        unitTrail.UnitAttachedTo = headNode.transform;
	//        unitTrail.UnitState = StateID.FOLLOWING;

	//        trailBody.name = "Trail Body " + GameManager.sharedInstance.UnitTrailBody.Count;
	//        trailBody.transform.position = headNode.transform.position - (unitHeadNode.UnitMoveDirection * GridManager.sharedInstance.GridSpacing);
	//        //trailBody.layer = LayerManager.TrailBodyLayer;
	//        trailBody.SetActive(true);
	//        GameManager.sharedInstance.UnitTrailBody.Add(trailBody);
	//    }
	//}

	//public static void AddTrail(AllyUnit newTrail) {
	//    int trailBodyLength = GameManager.sharedInstance.GetTrailBodyLength();
	//    GameObject tail = GameManager.sharedInstance.UnitTrailBody[trailBodyLength - 1];
	//    AllyUnit tailUnit = tail.GetComponent<AllyUnit>();

	//    //newTrail.Clone(tailUnit);
	//    newTrail.UnitAttachedTo = tail.transform;
	//    newTrail.UnitState = StateID.FOLLOWING;

	//    newTrail.name = "Trail Body " + GameManager.sharedInstance.UnitTrailBody.Count;
	//    newTrail.transform.position = tail.transform.position - (newTrail.UnitMoveDirection * GridManager.sharedInstance.GridSpacing);
	//    //newTrail.gameObject.layer = LayerManager.TrailBodyLayer;

	//    GameManager.sharedInstance.UnitTrailBody.Add(newTrail.gameObject);
	//}

	//public static void RemoveTrailHead() {
	//    int trailBodyLength = GameManager.sharedInstance.GetTrailBodyLength();
	//    if (trailBodyLength > 1) {
	//        GameObject oldHead = GameManager.sharedInstance.UnitTrailBody[0];
	//        AllyUnit oldHeadUnit = oldHead.GetComponent<AllyUnit>();

	//        GameObject newHead = GameManager.sharedInstance.UnitTrailBody[1];
	//        AllyUnit newHeadUnit = newHead.GetComponent<AllyUnit>();

	//        if (trailBodyLength > 2) {
	//            newHeadUnit.UnitAttachedTo = GameManager.sharedInstance.UnitTrailBody[2].transform;
	//        }

	//        //newHeadUnit.Clone(oldHeadUnit);
	//        newHeadUnit.UnitState = StateID.MOVING;

	//        oldHead.name = "Ally Unit";
	//        oldHead.SetActive(false);
	//        GameManager.sharedInstance.UnitTrailHead = newHead;
	//        GameManager.sharedInstance.UnitTrailHead.name = "Trail Head";
	//        GameManager.sharedInstance.UnitTrailBody.RemoveAt(0);

	//        trailBodyLength = GameManager.sharedInstance.GetTrailBodyLength();
	//        for (int i = 1; i < trailBodyLength; i++) {
	//            GameManager.sharedInstance.UnitTrailBody[i].name = "Trail Body " + i;
	//        }
	//    }
	//    else {
	//        GameObject oldHead = GameManager.sharedInstance.UnitTrailBody[0];
	//        oldHead.name = "Ally Unit";
	//        oldHead.SetActive(false);
	//        GameManager.sharedInstance.UnitTrailBody.RemoveAt(0);
	//    }
	//}

	//public static void SwapTrailElements() {
	//    int trailBodyLength = GameManager.sharedInstance.GetTrailBodyLength();
	//    GameObject obj = GameManager.sharedInstance.UnitTrailBody[0];
	//    AllyUnit objUnit = obj.GetComponent<AllyUnit>();
	//    UnitInformation unitInfo = new UnitInformation();
	//    //unitInfo = objUnit.UnitInfo;

	//    int trailLength = trailBodyLength;

	//    for (int i = 0; i < trailLength; i++) {
	//        GameObject obj1 = GameManager.sharedInstance.UnitTrailBody[i];
	//        AllyUnit objUnit1 = obj1.GetComponent<AllyUnit>();

	//        if (i < (trailLength - 1)) {
	//            GameObject obj2 = GameManager.sharedInstance.UnitTrailBody[i + 1];
	//            AllyUnit objUnit2 = obj2.GetComponent<AllyUnit>();

	//            objUnit1.UnitInfo = objUnit2.UnitInfo;
	//            objUnit1.SpRenderer.sprite = objUnit2.UnitInfo.UnitAvatar;
	//            //objUnit1.ChangeColorType(UnitUtilities.GetUnitColorByUnitType(objUnit1.UnitInfo.UnitColorType));
	//        }
	//        else {
	//            objUnit1.UnitInfo = unitInfo;
	//            objUnit1.SpRenderer.sprite = unitInfo.UnitAvatar;
	//            //objUnit1.ChangeColorType(UnitUtilities.GetUnitColorByUnitType(objUnit1.UnitInfo.UnitColorType));
	//        }
	//    }
	//}

	public static Color GetUnitColorByUnitType(RaceTypeID type) {
		Color resultColor = new Color();
		if (type == RaceTypeID.RED) {
			resultColor = Color.red;
		}
		else if (type == RaceTypeID.GREEN) {
			resultColor = Color.green;
		}
		else if (type == RaceTypeID.BLUE) {
			resultColor = Color.blue;
		}
		return resultColor;
	}

	public static string GetUnitName(TypeID type, ClassTypeID classType) {
		string resultString = string.Empty;
		resultString = (type == TypeID.ALLY) ? "[ALLY] " : "[ENEMY] ";

		if (classType == ClassTypeID.WARRIOR) {
			resultString += "Warrior";
		}
		else if (classType == ClassTypeID.ARCHER) {
			resultString += "Archer";
		}
		else if (classType == ClassTypeID.MAGE) {
			resultString += "Mage";
		}
		return resultString;
	}
}