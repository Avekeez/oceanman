// deadly lazer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : Weapon {
	public LineRenderer Laser;
	public ParticleSystem LaserCollision;
	public Light LaserLight;
	public Color LaserColor;

	public override void Fire() {
		WeaponExit exit = getExit();
		StartCoroutine(LaserFadeRoutine(exit));
	}
	IEnumerator LaserFadeRoutine(WeaponExit exit) {
		LineRenderer laser = Instantiate(Laser);

		laser.SetPosition(0,exit.Origin);
		Light origin = Instantiate(LaserLight,exit.Origin + exit.Direction * 0.1f,Quaternion.identity);
		Light destination = null;

		RaycastHit laserHit;
		if(Physics.Raycast(exit.Origin,exit.Direction,out laserHit,Mathf.Infinity,1 << 9)) {
			laser.SetPosition(1,laserHit.point);
			GameObject col = Instantiate(LaserCollision,laserHit.point,Quaternion.LookRotation(Vector3.Reflect(exit.Direction,laserHit.normal))).gameObject;
			Destroy(col,0.7f);
			destination = Instantiate(LaserLight,laserHit.point,Quaternion.identity);
		} else {
			laser.SetPosition(1,exit.Origin + exit.Direction * 100);
		}


		float alpha = 1;
		Gradient gr = new Gradient();
		gr.colorKeys = new[] { new GradientColorKey(LaserColor,0) };

		float intensity = origin.intensity;
		while(alpha >= 0) {
			//gr.alphaKeys = new[] { new GradientAlphaKey(alpha,0) };
			gr.colorKeys = new[] { new GradientColorKey(Color.Lerp(LaserColor,Color.white,1 - alpha),0) };
			laser.colorGradient = gr;

			//laser.widthCurve = new AnimationCurve(new Keyframe(1 - alpha, 0),new Keyframe(1,1));
			laser.widthMultiplier = alpha;

			origin.intensity = intensity * alpha;
			if(destination != null)
				destination.intensity = 10*intensity * alpha;

			alpha -= 0.025f / Mathf.Pow(alpha,1.2f);
			yield return null;
		}
		Destroy(origin.gameObject);
		Destroy(laser.gameObject);
		if(destination != null)
			Destroy(destination.gameObject);
	}
}