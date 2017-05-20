using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {
	public static Vector3? MousePos (this Camera cam, LayerMask layermask) {
		Vector3 input = Input.mousePosition;
		input.x = Mathf.Clamp (input.x, 0, Screen.width);
		input.y = Mathf.Clamp (input.y, 0, Screen.height);
		Ray ray = cam.ScreenPointToRay (input);
		
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, layermask)) {
			return hit.point;
		}
		return null;
	}
	public static Vector3 SetY (this Vector3 vec, float y) {
		return new Vector3 (vec.x, y, vec.z);
	}
	public static Vector3 SetX (this Vector3 vec, float x) {
		return new Vector3 (x, vec.y, vec.z);
	}
	public static Vector3 SetZ (this Vector3 vec, float z) {
		return new Vector3 (vec.x, vec.y, z);
	}
}
