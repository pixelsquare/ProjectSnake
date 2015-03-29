using UnityEngine;
using System.Collections;

public static class LayerManager {

	// Public Variables
	private static string defaultLayer = "Default";
	public static int DefaultLayer {
		get { return LayerMask.NameToLayer(defaultLayer); }
	}

	private static string gridLayer = "Grid";
	public static int GridLayer {
		get { return LayerMask.NameToLayer(gridLayer); }
	}

	private static string wallLayer = "Wall";
	public static int WallLayer {
		get { return LayerMask.NameToLayer(wallLayer); }
	}

	private static string unitLayer = "Unit";
	public static int UnitLayer {
		get { return LayerMask.NameToLayer(unitLayer); }
	}

	// Private Variables

	// Static Variables
}