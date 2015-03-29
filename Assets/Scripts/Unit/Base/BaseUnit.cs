using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class BaseUnit : MonoBehaviour {

	// Public Variables

	// Private Variables
	private SpriteRenderer spRenderer;
	public SpriteRenderer SpRenderer {
		get { return spRenderer; }
	}

	private Rigidbody2D rBody2D;
	public Rigidbody2D RBody2D {
		get { return rBody2D; }
	}

	// Static Variables

	protected virtual void Start() {
		spRenderer = GetComponent<SpriteRenderer>();
		rBody2D = GetComponent<Rigidbody2D>();
		rBody2D.isKinematic = true;
	}
}