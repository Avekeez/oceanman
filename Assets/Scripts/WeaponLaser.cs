// deadly lazer
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : Weapon {	
	public LineRenderer Laser;
	
	public Color LaserColor;
	
	public override void Fire () {
		StartCoroutine (LaserFadeRoutine());
	}
	IEnumerator LaserFadeRoutine () {
		LineRenderer laser = Instantiate (Laser);
		WeaponExit exit = getExit();
		laser.SetPosition (0, exit.Origin);
		laser.SetPosition (1, exit.Origin + exit.Direction * 100);
		
		float alpha = 1;
		Gradient gr = new Gradient();
		gr.colorKeys = new [] {new GradientColorKey (LaserColor, 0)};
		while (alpha >= 0) {
			gr.alphaKeys = new [] {new GradientAlphaKey (alpha, 0)};
			laser.colorGradient = gr;
			alpha -= 0.02f/alpha/alpha;
			yield return null;
		}
		Destroy (laser.gameObject);
	}
}