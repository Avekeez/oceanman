using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour {
	CharacterController controller;
	public void Awake () {
		controller = GetComponent<CharacterController>();
	}
	public void Update () {
		controller.Move (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * Time.deltaTime * 30);
	}
}
