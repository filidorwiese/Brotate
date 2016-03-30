using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiController : MonoBehaviour {
	[SerializeField] Image progression;

	Animator anim;
	int jumpHash = Animator.StringToHash("progress");

	private float step;
	private float screenWidth;
	private int duration = 10;
	private decimal waitPerFrame = 0.04m;
	private float progressWidth;

	// given a screen width of 796px
	// 796px  / 10s = 79.6 px/s
	// 79.6 * waitPerFrame = 3.18px/fr
	void Awake() {

	}

	void Start() {
		//anim = GetComponent<Animator> ();
		//anim.SetTrigger (jumpHash);
	}

	void Update() {

	}

	public void RestartLevel() {
		Application.LoadLevel ("Main");
	}
}
