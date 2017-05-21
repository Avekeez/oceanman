using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {
	public LayerMask mask;

	public Transform[] WeaponMounts = new Transform[2];
	public Weapon[] Weapons = new Weapon[2];

	[HideInInspector]
	public Vector3 Position;

	private PlayerModel model;

	void Awake() {
		model = GetComponentInChildren<PlayerModel>();
	}

	void Update() {
		Vector3? result = Camera.main.MousePos(mask);
		if(result != null) {
			Position = result.Value;
			print(Position.y);
		}
		Vector3 flatPos = Position;
		flatPos.y = 0;

		Vector3 targetDir = (flatPos - transform.position.SetY(0)).normalized;
		print(targetDir.y);
		if(model != null) {
			model.TargetDirection = targetDir;
			Debug.DrawRay(model.transform.position,targetDir * 10);
		}

		Vector3 target;
		RaycastHit hit;
		if(Physics.Raycast(model.transform.position,targetDir,out hit,Mathf.Infinity,1 << 9)) {
			target = hit.point;
		} else {
			target = Position;
		}

		for(int i = 0; i < 2; i++) {
			Transform mount = WeaponMounts[i];
			mount.LookAt(target);
		}

		if(Input.GetMouseButton(0)) {
			foreach(Weapon weapon in Weapons) {
				weapon.Fire();
			}
		}
	}
}
