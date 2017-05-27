using System;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	WeaponExit[] ExitPoints;

	public float Kickback;

	public virtual void Awake() {
		ExitPoints = transform.GetComponentsInChildren<WeaponExit>();
	}
	public virtual void Fire() {
		throw new NotImplementedException("Fire not implemented for weapon");
	}

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