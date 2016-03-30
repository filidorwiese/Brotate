using UnityEngine;
using System.Collections;

public class BroController : MonoBehaviour {

	private bool isRotating = false;
	private float totalRotation = 0;
	private float rotationSpeed = 8.0f;
	private float rotationDegreesAmount = 90.0f;
	private Quaternion targetRotation;
	private Vector3 targetDirection;
	private Quaternion targetEnd;

	private Vector3 correctRotation;
	private bool rotatedCorrectly = false;

	void Awake () {
		// Store correct position
		correctRotation = transform.rotation.eulerAngles;

		// Start in a random position
		float RandomX = Random.Range (-1, 2) * 90;
		float RandomZ = Random.Range (-1, 2) * 90;
		transform.Rotate(RandomX, RandomZ, 0);
	}

	void Update () {
		if (this.isRotating) {
			float speed = rotationSpeed * rotationDegreesAmount * Time.deltaTime;

			// Rotate towards direction
			Quaternion targetRotation = Quaternion.AngleAxis (speed, targetDirection);
			transform.rotation = targetRotation * transform.rotation;

			// Count amount of rotation
			totalRotation += speed;

			// If totalRotation equals the amount to rotate, end rotation
			if (Mathf.Abs (totalRotation) >= Mathf.Abs (rotationDegreesAmount)) {
				transform.rotation = targetEnd;
				totalRotation = 0;
				isRotating = false;

				//Debug.Log (transform.rotation.eulerAngles + " " + correctRotation);

				if (V3Equal(transform.rotation.eulerAngles, correctRotation)) {
					rotatedCorrectly = true;
				} else {
					rotatedCorrectly = false;
				}
			}
		}
	}

	public void SetRotation(Directions direction) {
		if (!this.isRotating) {
			// Determine target direction
			switch (direction) {
				case Directions.LEFT:
					targetDirection = Vector3.up;
					break;
				case Directions.RIGHT:
					targetDirection = Vector3.down;
					break;
				case Directions.UP:
					targetDirection = Vector3.right;
					break;
				case Directions.DOWN:
					targetDirection = Vector3.left;
					break;
			}

			//targetDirection = Vector3.right + Vector3.down;

			// Store end position
			Quaternion tmp = Quaternion.AngleAxis (rotationDegreesAmount, targetDirection);
			targetEnd = tmp * transform.rotation;

			this.isRotating = true;
		}		
	}

	public bool isRotatedCorrectly() {
		return rotatedCorrectly;
	}

	public bool V3Equal(Vector3 a, Vector3 b){
		return Vector3.SqrMagnitude(a - b) < 0.0001;
	}
}
