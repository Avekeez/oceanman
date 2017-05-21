using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour {
	CharacterController controller;
	private Vector3 ExternalInfluence;
	public void Awake() {
		controller = GetComponent<CharacterController>();
	}
	public void Update() {
		controller.Move(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")) * Time.deltaTime * 30);
		controller.Move(ExternalInfluence * Time.deltaTime);
		ExternalInfluence = Vector3.Lerp(ExternalInfluence,Vector3.zero,10*Time.deltaTime);
	}
	public void Influence (Vector3 force) {
		ExternalInfluence += force;
	}
}
