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
			Debug.Log ("Keydown W");
			_broLCtrl.SetRotation(Directions.UP);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			Debug.Log ("Keydown S");
			_broLCtrl.SetRotation(Directions.DOWN);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			Debug.Log ("Keydown A");
			_broLCtrl.SetRotation(Directions.LEFT);
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			Debug.Log ("Keydown D");
			_broLCtrl.SetRotation(Directions.RIGHT);
		}
		/*
		if (Input.GetKeyDown (KeyCode.N)) {
			Debug.Log ("Keydown N");
			_broRCtrl.RotateY ();
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			Debug.Log ("Keydown M");
			_broRCtrl.RotateX ();
		}*/
	}
}
