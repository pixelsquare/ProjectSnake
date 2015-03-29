using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Console : MonoBehaviour {

	// Public Variables
	[SerializeField]
	private Text consoleTextLog;

	[SerializeField]
	private Button consoleButton;

	[SerializeField]
	private Text consoleInputLog;

	[SerializeField]
	private ScrollRect consoleScrollRect;

	// Private Variables

	// Static Variables

	private void Awake() {
		consoleTextLog.text += "\n";
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			InputToTextLog();
		}
	}

	public void InputToTextLog() {
		consoleTextLog.text += "\n> " + consoleInputLog.text;
		//consoleInputLog.text = string.Empty;
		//consoleTextLog.rectTransform.sizeDelta += new Vector2(0f, 1f) * 16f;
	}
}