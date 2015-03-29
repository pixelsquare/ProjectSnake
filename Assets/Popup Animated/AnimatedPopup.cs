using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimatedPopup : MonoBehaviour {

	// Public Variables
	[SerializeField]
	private SpriteRenderer spRenderer;

	[SerializeField]
	private List<Sprite> numberList;

	// Private Variables
	private Dictionary<int, Sprite> sprite;

	// Static Variables

	private void Awake() {
		sprite = new Dictionary<int, Sprite>();

		if (numberList != null) {
			for (int i = 0; i < numberList.Count; i++) {
				sprite.Add(i, numberList[i]);
			}
		}
	}

	public void Initialize(int damage) {
		Sprite sp = null;
		if (sprite.TryGetValue(damage, out sp)) {
			spRenderer.sprite = sp;
		}
	}

	private void DisablePopup() {
		gameObject.SetActive(false);
	}
}