using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlePopup : MonoBehaviour {

	// Public Variables
	[SerializeField]
	private List<Material> numberMat;

	// Private Variables
	private Dictionary<int, Material> numberDictionary;
	private ParticleSystem pSystem;

	// Static Variables

	private void Awake() {
		pSystem = GetComponent<ParticleSystem>();
		numberDictionary = new Dictionary<int, Material>();

		if (numberMat != null) {
			for (int i = 0; i < numberMat.Count; i++) {
				numberDictionary.Add(i, numberMat[i]);
			}
		}
	}

	public void Initialize(int num) {
		Material material = null;
		if (numberDictionary.TryGetValue(num, out material)) {
			pSystem.renderer.sharedMaterial = material;
		}
	}
}