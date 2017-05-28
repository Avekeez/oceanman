using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform Follow;
	public PlayerAim playerAim;

	private Vector3 pivot;
	private Vector3 aim;

	private Vector3 shakeDir;
	private float shakeProgress;

	public void Awake() {
		pivot = Follow.position;
	}

	public void Update() {
		Vector3 targetPosition = Follow.position.SetY(0);
		if(playerAim != null) {
			aim = Vector3.Lerp(aim,Vector3.LerpUnclamped(pivot,playerAim.Position.SetY(0),0.25f * (1f - 0.7f * Mathf.Clamp01(Input.mousePosition.y / (float)Screen.height))) - pivot,6 * Time.deltaTime);
		}

		pivot = Vector3.Lerp(pivot,targetPosition,12 * Time.deltaTime);

		Vector3 position = pivot + aim;

		transform.position = position
			+ (Vector3.up * 18f - Vector3.forward * 12);
		//+ Vector3.up * (position.z <= 0 ? -position.z : 0) * 0.25f;
		transform.LookAt(position);

		transform.position += shakeDir * Mathf.Sin(shakeProgress * 12 * Mathf.PI) * (0.3f-shakeProgress) * 3;

		if (shakeProgress < 0.3f) {
			shakeProgress += Time.deltaTime + (shakeProgress < 0 ? -shakeProgress : 0);
		} else {
			shakeProgress = 0.3f;
		}
	}

	public void SetShake(Vector3 Direction) {
		shakeDir = Direction;
		shakeProgress = 0;
	}
	public void AddShake(Vector3 Direction) {
		shakeDir = Direction;
		shakeProgress -= 0.3f;
	}
}
