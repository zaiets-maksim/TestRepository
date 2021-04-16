using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChild : MonoBehaviour {
	private Rigidbody _rigibody;
	[Range(0, 5)]
	[SerializeField] private float _speed;
	
	private void Start () {
		_rigibody = GetComponent<Rigidbody>();
	}
	
	private void Update() {
		Move();
	}

	private void Move(){
		_rigibody.velocity = new Vector3(_rigibody.velocity.x, _rigibody.velocity.y,_speed);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Enemy")){
			other.gameObject.GetComponent<Animation>().Play("InfectionEnemy");
		}
		if(other.CompareTag("Door")){
			gameObject.SetActive(false);
		}
	}
	private void OnCollisionEnter(Collision other) {
		if(other.collider.CompareTag("Enemy")){
			gameObject.SetActive(false);
		}
	}
}
