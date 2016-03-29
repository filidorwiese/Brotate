using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {
	[SerializeField] Image progression;
	[SerializeField] Text WinnerText;
	[SerializeField] private Transform BroL;
	[SerializeField] private Transform BroR;

	private BroController _broLCtrl;
	private BroController _broRCtrl;

	private float waitSeconds = 8.0f;
	private float elapsedTime = 0;
	private bool playing = true;

	void Start () {
		WinnerText.gameObject.SetActive(false);
		_broLCtrl = BroL.GetComponent<BroController> ();
		_broRCtrl = BroR.GetComponent<BroController> ();
	}

	void Update() {
		if (playing) {
			Progression ();

			if (_broLCtrl.isRotatedCorrectly () && _broRCtrl.isRotatedCorrectly ()) {
				setWinning ();
			}
		}
	}

	public void RestartLevel() {
		SceneManager.LoadScene("Main");
	}

	private void Progression() {
		elapsedTime += Time.deltaTime;
		float onePercent = (Screen.width / 100);
		float percentage = (elapsedTime / waitSeconds) * 100;

		if (percentage <= 100) {
			progression.rectTransform.sizeDelta = new Vector2 (onePercent * percentage, 10);
		} else {
			setLost ();
		}
	}

	private void setWinning() {
		WinnerText.gameObject.SetActive(true);
		WinnerText.text = "Winner";
		playing = false;
	}

	private void setLost() {
		WinnerText.gameObject.SetActive(true);
		WinnerText.text = "Lost";
		playing = false;
	}

}
