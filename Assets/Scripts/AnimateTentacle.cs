using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AnimateTentacle : MonoBehaviour {
	public Transform[] Points;
	LineRenderer ren;

	void Awake () {
		ren = GetComponent<LineRenderer>();
		ren.positionCount = Points.Length;
	}

	void Update () {
		if(Points == null)
			return;
		for (int i = 0; i < Points.Length; i ++) {
			ren.SetPosition(i,Points[i].position);
		}
	}
}
