// deadly lazer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : Weapon {
	public LineRenderer Laser;
	public ParticleSystem LaserCollision;

	public Color LaserColor;

	public override void Fire() {
		StartCoroutine(LaserFadeRoutine());
	}
	IEnumerator LaserFadeRoutine() {
		LineRenderer laser = Instantiate(Laser);
		WeaponExit exit = getExit();
		laser.SetPosition(0,exit.Origin);

		RaycastHit laserHit;
		if(Physics.Raycast(exit.Origin,exit.Direction,out laserHit,Mathf.Infinity,1 << 9)) {
			laser.SetPosition(1,laserHit.point);
			GameObject col = Instantiate(LaserCollision,laserHit.point,Quaternion.LookRotation(Vector3.Reflect(exit.Direction,laserHit.normal))).gameObject;
			Destroy(col,0.7f);
		} else {
			laser.SetPosition(1,exit.Origin + exit.Direction * 100);
		}

		float alpha = 1;
		Gradient gr = new Gradient();
		gr.colorKeys = new[] { new GradientColorKey(LaserColor,0) };
		while(alpha >= 0) {
			gr.alphaKeys = new[] { new GradientAlphaKey(alpha,0) };
			laser.colorGradient = gr;
			alpha -= 0.02f / alpha / alpha;
			yield return null;
		}
		Destroy(laser.gameObject);
	}
}