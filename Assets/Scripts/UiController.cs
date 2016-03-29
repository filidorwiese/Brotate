using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiController : MonoBehaviour {
	[SerializeField] Image progression;

	private float onePercent;
	private float waitPerFrame = 0.01f;

	void Awake() {
		onePercent = Screen.width / 10 * waitPerFrame;
		//Debug.Log (onePercent);
		StartCoroutine(TimeGoesOn ());
	}

	void Update() {

	}

	public void RestartLevel() {
		Application.LoadLevel ("Main");
	}

	private IEnumerator TimeGoesOn() {
		for (int i = 0; i <= Screen.width; i++) {
			progression.rectTransform.sizeDelta = new Vector2 (onePercent * i, 10);
			//Debug.Log (progression.rectTransform.rect.width);
			yield return new WaitForSeconds (waitPerFrame);
		}
		Debug.Log ("done");
	}
}
