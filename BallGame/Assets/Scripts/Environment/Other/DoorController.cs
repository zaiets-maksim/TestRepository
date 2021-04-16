using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
	Animation _animation;
	[SerializeField] private GameObject _player;
	private void Start () {
		_animation = GetComponent<Animation>();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")){
			_animation.Play("DoorOpening");
		}
	}
	
}
