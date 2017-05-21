using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	WeaponExit[] ExitPoints;

	public virtual void Awake() {
		ExitPoints = transform.GetComponentsInChildren<WeaponExit>();
	}
	public virtual void Fire() { }

	public WeaponExit getExit() {
		//TODO everything
		return ExitPoints[0];
	}
}

public enum FireType {
	Random,
	Sequential
}

public enum WeaponType {
	Laser,
	Torpedo,
	Melee
}