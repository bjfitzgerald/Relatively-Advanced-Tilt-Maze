using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotController : MonoBehaviour {

	public float turnSpeed;

	private bool isSpinning;
	private float timeUntilNextTurn;
	private float degreesRemaining;
	private int randDir;

	// Use this for initialization
	void Start () {
		turnSpeed = 90f;
		degreesRemaining = 90f;

		int randPos = Random.Range (1, 5);		// EAST DEFAULT

		if (randPos == 2) { 
			transform.Rotate (Vector3.up, 90);	// SOUTH
		} else if (randPos == 3) {
			transform.Rotate (Vector3.up, 180);	// WEST
		} else if (randPos == 4) {
			transform.Rotate (Vector3.up, 270);	// NORTH
		}
			
		timeUntilNextTurn = Random.Range (2, 11);
		isSpinning = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeUntilNextTurn <= 0f && !isSpinning) {
			timeUntilNextTurn = 11f;
	
			// 1 = CW, 2 = CCW
			randDir = Random.Range (1, 3);

			isSpinning = true;
		} else if (isSpinning) {
			if (randDir == 1) {
				transform.Rotate (new Vector3 (0, 1, 0) * turnSpeed * Time.deltaTime);
			} else if (randDir == 2) {
				transform.Rotate (new Vector3 (0, -1, 0) * turnSpeed * Time.deltaTime);
			}
			degreesRemaining = degreesRemaining - (turnSpeed * Time.deltaTime);

			if (degreesRemaining <= 0) {
				isSpinning = false;
				degreesRemaining = 90;
			}
		} else {
			timeUntilNextTurn = timeUntilNextTurn - Time.deltaTime;
		}
	}
}
