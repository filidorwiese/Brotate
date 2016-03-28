using UnityEngine;
using System.Collections;

public class BroController : MonoBehaviour {
	
	private float totalRotation = 0;
	private float rotationSpeed = 4.0f;
	private float rotationDegreesAmount = 90.0f;
	private bool isRotating = false;
	private Quaternion targetRotation;
	private Vector3 targetDirection;
	private Quaternion targetEnd;

	void Update () {
		if (this.isRotating) {
			float speed = rotationSpeed * rotationDegreesAmount * Time.deltaTime;

			Quaternion targetRotation = Quaternion.AngleAxis (speed, targetDirection);
			transform.rotation = targetRotation * transform.rotation;
			totalRotation += speed;

			if (Mathf.Abs (totalRotation) >= Mathf.Abs (rotationDegreesAmount)) {
				Debug.Log (targetEnd + " " + transform.rotation.eulerAngles);
				transform.rotation = targetEnd;
				totalRotation = 0;
				isRotating = false;
			}
		}
	}

	public void SetRotation(Directions direction) {
		if (!this.isRotating) {
			if (direction == Directions.LEFT) {
				targetDirection = Vector3.up;
			}
			if (direction == Directions.RIGHT) {
				targetDirection = Vector3.down;
			}
			if (direction == Directions.UP) {
				targetDirection = Vector3.right;
			}
			if (direction == Directions.DOWN) {
				targetDirection = Vector3.left;
			}

			// Store end position
			Quaternion tmp = Quaternion.AngleAxis (rotationDegreesAmount, targetDirection);
			targetEnd = tmp * transform.rotation;

			this.isRotating = true;
		}		
	}
}
