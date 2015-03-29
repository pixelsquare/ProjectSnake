using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class Popup : MonoBehaviour {

	// Public Variables
	[SerializeField]
	private List<Sprite> numberList;

	// Private Variables
	private SpriteRenderer spRenderer;
	private Color spriteColor;
	private float spriteColorAlpha;
	private Dictionary<int, Sprite> sprite;

	private enum FadeState { NONE, IN, OUT }
	private FadeState fadeState;

	private Vector3 moveVelocity;
	private Vector3 targetPosition;
	private float moveDampTime = 0.9f;

	private const float FADE_OUT_THRESHOLD = 0.75f;

	// Static Variables

	private void Awake() {
		spRenderer = GetComponent<SpriteRenderer>();
		spriteColor = spRenderer.color;
		spriteColorAlpha = spRenderer.color.a;
		sprite = new Dictionary<int, Sprite>();

		if (numberList != null) {
			for (int i = 0; i < numberList.Count; i++) {
				sprite.Add(i, numberList[i]);
			}
		}
	}

	private void Update() {
		float distance = Vector3.Distance(transform.position, targetPosition);
		if (distance > 0f) {
			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, moveDampTime);

			if (distance < (1 - FADE_OUT_THRESHOLD) && fadeState != FadeState.OUT) {
				fadeState = FadeState.OUT;
				StartCoroutine(Fade());
			}
		}
	}

	private IEnumerator Fade() {
		if (fadeState == FadeState.IN) {
			spriteColorAlpha = 0f;
			spriteColor.a = spriteColorAlpha;

			float time = 0f;
			while (time < 1f) {
				spriteColorAlpha = Mathf.Lerp(spriteColorAlpha, 1f, Mathf.PingPong(time, 1f) / 1f);
				spriteColor.a = spriteColorAlpha;
				spRenderer.color = spriteColor;
				time += Time.deltaTime;
				yield return null;
			}
		}
		else if (fadeState == FadeState.OUT) {
			spriteColorAlpha = 1f;
			spriteColor.a = spriteColorAlpha;

			float time = 0f;
			while (time < 1f) {
				spriteColorAlpha = Mathf.Lerp(spriteColorAlpha, 0f, Mathf.PingPong(time, 1f) / 1f);
				spriteColor.a = spriteColorAlpha;
				spRenderer.color = spriteColor;
				time += Time.deltaTime;
				yield return null;
			}

			gameObject.SetActive(false);
		}
	}

	public void Initialize(int damage) {
		Sprite sp = null;
		if(sprite.TryGetValue(damage, out sp)) {
			spRenderer.sprite = sp;
		}
		targetPosition = transform.position + (Vector3.up * 0.5f);
		fadeState = FadeState.IN;
		StartCoroutine(Fade());
	}
}