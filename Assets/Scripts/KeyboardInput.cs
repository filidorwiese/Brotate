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
		if (Input.GetKeyDown (KeyCode.D)) {
			Debug.Log ("Keydown D");
			_broLCtrl.RotateX ();
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			Debug.Log ("Keydown F");
			_broLCtrl.RotateY ();
		}

		if (Input.GetKeyDown (KeyCode.N)) {
			Debug.Log ("Keydown N");
			_broRCtrl.RotateY ();
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			Debug.Log ("Keydown M");
			_broRCtrl.RotateX ();
		}
	}
}
