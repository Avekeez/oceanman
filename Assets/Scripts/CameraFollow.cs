using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform Follow;
	public PlayerAim playerAim;
	
	private Vector3 pivot;
	private Vector3 aim;
	public void Awake () {
		pivot = Follow.position;
	}
	
	public void Update () {
		Vector3 target = Follow.position.SetY(0);
		
		pivot = Vector3.Lerp (pivot, target, 12 * Time.deltaTime);
		if (playerAim != null) {
			aim = Vector3.LerpUnclamped (pivot, playerAim.Position.SetY(0), 0.15f * (1f - 0.7f * Mathf.Clamp01 (Input.mousePosition.y/(float)Screen.height))) - pivot;
		}
		
		Vector3 position = pivot + aim;
		
		transform.position = position 
			+ (Vector3.up * 12f - Vector3.forward * 9);
			//+ Vector3.up * (position.z <= 0 ? -position.z : 0) * 0.25f;
		transform.LookAt (position);
	}
}
