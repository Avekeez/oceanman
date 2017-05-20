using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {
	public Vector3 TargetDirection;
	
	void LateUpdate () {
		transform.rotation = Quaternion.LookRotation (Vector3.Slerp (transform.forward, TargetDirection, 6 * Time.deltaTime));
	}
}
