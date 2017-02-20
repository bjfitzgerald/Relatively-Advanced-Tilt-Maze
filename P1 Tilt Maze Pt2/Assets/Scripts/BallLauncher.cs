using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour {

	public Rigidbody rb;
	public float thrust;
	public Vector3 jump;
	public Text countText;
	public Text loserText;

	private int pickUpsFound;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		thrust = 10f;
		jump = new Vector3 (0.0f, 200.0f, 0.0f);
		pickUpsFound = 0;
		countText.text = "Pick-ups remaining: " + (2 - pickUpsFound).ToString();
		loserText.text = "Sorry. You Lose!";
		loserText.gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

		if (transform.position.y <= -10) {
			countText.gameObject.SetActive (false);
			loserText.gameObject.SetActive (true);
		}

		if (rb.isKinematic) {
			rb.transform.Translate (Vector3.up * Time.deltaTime * thrust, Space.World);
			countText.text = "Congratulations! You win!";
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			rb.AddForce (jump);
		}
	}
		
	void OnTriggerEnter(Collider other) {
		// When the ball hits a pick up
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			pickUpsFound++;
			if (pickUpsFound >= 2) {
				countText.text = "Done! Go to the goal!";
			} else {
				countText.text = "Pick-ups remaining: " + (2 - pickUpsFound).ToString();
			}
		}

		// When the ball hits the goal
		if (other.name == "Goal Particles" && pickUpsFound >= 2) {
			rb.isKinematic = true;
		}
	}
}
