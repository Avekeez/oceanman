using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour {
	float StartTime;

	bool hasLaunched = false;

	public ParticleSystem Exhaust;
	public ParticleSystem Initial;

	Transform Model;

	void Awake () {
		Model = transform.FindChild("Model");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !hasLaunched) {
			Launch();
		}
	}

	void Launch () {
		hasLaunched = true;
		StartTime = Time.time;
		Exhaust.Play();
		Initial.Play();
    }

	void FixedUpdate () {
		if (hasLaunched) {
			GetComponent<Rigidbody>().AddForce(transform.forward * 50 * (Time.time-StartTime));
			transform.Rotate (transform.up, (Time.time - StartTime)/10f);
			Model.Rotate(Model.forward,-6*(Time.time - StartTime), Space.World);
		}
	}
}
