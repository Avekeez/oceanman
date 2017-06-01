using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Light))]
public class AnimateCaustic : MonoBehaviour {
	public Gradient ColorGrad;
	public float Duration = 10;
	public float Offset;

	public Vector3 MoveDirection = Vector3.forward;
	public float Speed = 5;
	public float RotationSpeed = 1;

	private Light light;

	private float cookieSize;

	void Awake () {
		light = GetComponent<Light>();
		transform.position = Vector3.one * (2 * Random.value - 1) * 100;
		cookieSize = light.cookieSize;
		MoveDirection.Normalize();
	}

	void Update () {
		float time = 0.5f * Mathf.Sin((2 * Mathf.PI) / Duration * (Time.time-Offset)) + 0.5f;
        light.intensity = ColorGrad.Evaluate(time).a * 0.5f+0.1f;
		light.cookieSize = cookieSize * (1 + Mathf.Cos(time + Offset * 5) * 0.01f);
		if (light.intensity < 1e-4) {
			transform.position = -MoveDirection * Random.value * 100;
		}
		transform.position += Speed * Time.deltaTime * MoveDirection;
		transform.Rotate(Vector3.up,Time.deltaTime * RotationSpeed, Space.World);
	}
}
