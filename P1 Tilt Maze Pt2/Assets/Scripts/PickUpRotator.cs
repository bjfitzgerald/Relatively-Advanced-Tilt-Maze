using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {

		float randX = 0f;
		float randZ = 0f;

		while ((randX + randZ == -1) || (randZ == -1 && randX == -1) || 
			(randX + randZ == 0) || (randX + randZ == 8)) {
			randX = Random.Range (-5, 5);
			randZ = Random.Range (-5, 5);
		}
			
		transform.Translate (new Vector3(randX, 0, randZ), Space.World);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
