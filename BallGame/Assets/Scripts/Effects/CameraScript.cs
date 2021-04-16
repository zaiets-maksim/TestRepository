using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	[SerializeField] private Transform _player;

	[Range(0.1f, 15f)]
	[SerializeField] private float _offsetZ;

	private void FixedUpdate() {
		LookAtPlayer();
	}
		void LookAtPlayer(){
		transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, _player.transform.position.z - _offsetZ);
	}
}
