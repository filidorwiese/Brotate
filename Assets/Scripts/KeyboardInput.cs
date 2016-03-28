using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	[SerializeField] private Transform BroL;
	[SerializeField] private Transform BroR;
	private GameObject WinnerText;

	private BroController _broLCtrl;
	private BroController _broRCtrl;

	void Start() {
		_broLCtrl = BroL.GetComponent<BroController> ();
		_broRCtrl = BroR.GetComponent<BroController> ();

		WinnerText = GameObject.Find ("Winner");
		WinnerText.gameObject.SetActive(false);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			_broLCtrl.SetRotation(Directions.UP);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			_broLCtrl.SetRotation(Directions.DOWN);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			_broLCtrl.SetRotation(Directions.LEFT);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			_broLCtrl.SetRotation(Directions.RIGHT);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			_broRCtrl.SetRotation(Directions.UP);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			_broRCtrl.SetRotation(Directions.DOWN);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			_broRCtrl.SetRotation(Directions.LEFT);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			_broRCtrl.SetRotation(Directions.RIGHT);
		}

		if (_broLCtrl.isRotatedCorrectly () && _broRCtrl.isRotatedCorrectly ()) {
			WinnerText.gameObject.SetActive(true);
			Debug.Log ("We got a winner");
		}
	}
}
