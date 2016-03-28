using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	[SerializeField] private Transform BroL;
	[SerializeField] private Transform BroR;

	private BroController _broLCtrl;
	private BroController _broRCtrl;

	void Start() {
		_broLCtrl = BroL.GetComponent<BroController> ();
		_broRCtrl = BroR.GetComponent<BroController> ();
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
			Debug.Log ("We got a winner");
		}
	}
}
