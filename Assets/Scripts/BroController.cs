using UnityEngine;
using System.Collections;

public class BroController : MonoBehaviour {
	
	private float totalRotation = 0;
	private float rotationSpeed = 15.0f;
	private float rotationDegreesAmount = 90f;
	private bool isRotating = false;
	private Quaternion targetRotation;

	private float currentAngle;

	void Update () {
		if (isRotating) {
			float speed = rotationSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed);
			totalRotation += speed;

			Debug.Log (transform.rotation.eulerAngles + " " + targetRotation.eulerAngles + " " + totalRotation);

			if (Mathf.Abs (totalRotation) >= rotationSpeed) {
				Debug.Log("DONE!!!");
				transform.rotation = targetRotation;
				totalRotation = 0;
				isRotating = false;
			}
		}
	}
		
	public void RotateX() {
		if (!isRotating) {
			this.isRotating = true;
			this.targetRotation = Quaternion.Euler (this.transform.rotation.eulerAngles.x - rotationDegreesAmount, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
		}

		Debug.Log (transform.rotation.eulerAngles + " " + targetRotation.eulerAngles);
		//this.transform.Rotate(new Vector3 (-90, 0, 0));

	}

	public void RotateY() {
		if (!isRotating) {
			this.isRotating = true;	
			this.targetRotation = Quaternion.Euler (this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z - rotationDegreesAmount);
		}
		Debug.Log (transform.rotation.eulerAngles + " " + targetRotation.eulerAngles);
		//this.transform.Rotate(new Vector3 (0, 0, -90));
	}

}
