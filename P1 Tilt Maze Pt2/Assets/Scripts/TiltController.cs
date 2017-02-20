using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiltController : MonoBehaviour {

	public float tiltSensitivity;
	public Vector3 currentRot;

	// Use this for initialization
	void Start () {
		tiltSensitivity = 20f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if (Input.GetKeyDown (KeyCode.Q) || Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		currentRot = GetComponent<Transform> ().eulerAngles;

//		normalizeRotation ();

		if ((Input.GetAxis ("Horizontal") > 0.2) && (currentRot.z >= 349 || currentRot.z <= 11)) 
		{
			transform.Rotate(new Vector3(0, 0, -1) * tiltSensitivity * Time.deltaTime);
		}

		if (Input.GetAxis ("Horizontal") < -0.2 && (currentRot.z <= 10 || currentRot.z >= 348)) 
		{
			transform.Rotate(new Vector3(0, 0, 1) * tiltSensitivity * Time.deltaTime);
		}

		if (Input.GetAxis ("Vertical") > 0.2 && (currentRot.x <= 10 || currentRot.x >= 348)) 
		{
			transform.Rotate(new Vector3(1, 0, 0) * tiltSensitivity * Time.deltaTime);
		}

		if (Input.GetAxis ("Vertical") < -0.2 && (currentRot.x >= 349 || currentRot.x <= 11)) 
		{
			transform.Rotate(new Vector3(-1, 0, 0) * tiltSensitivity * Time.deltaTime);
		}
	}

	private void normalizeRotation() {
		if (currentRot.x > 180) 
		{
			currentRot.x = currentRot.x - 180;
		}

		if (currentRot.y > 180) 
		{
			currentRot.y = currentRot.y - 180;
		}

		if (currentRot.z > 180) 
		{
			currentRot.z = currentRot.z - 180;
		}
	}
}
