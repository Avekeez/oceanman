using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponExit : MonoBehaviour {
	public ExitType Type;
	[Tooltip("Represents the index of the exit, only considered with sequential")]
	public int Index = -1;

	public Vector3 Origin {
		get {
			return transform.position;
		}
	}
	public Vector3 Direction {
		get {
			return transform.forward;
		}
	}
}

public enum ExitType {
	Random,
	Sequential
}
