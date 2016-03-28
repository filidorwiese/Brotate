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

	void Awake () {
		// Start in a random position
		float RandomX = Random.Range (-1, 2) * 90;
		float RandomZ = Random.Range (-1, 2) * 90;
		transform.Rotate(RandomX, 0, RandomZ);
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

			// Store end position
			Quaternion tmp = Quaternion.AngleAxis (rotationDegreesAmount, targetDirection);
			targetEnd = tmp * transform.rotation;

			this.isRotating = true;
		}		
	}
}
