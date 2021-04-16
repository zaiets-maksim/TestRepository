using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody _rigibody;
	[Range(0, 3)]
	[SerializeField] private float _speed;
	[SerializeField] private Transform _target;
	private Vector3 RayPosition;
	private Vector3 TargetPosition;

	private void Start () {
		_rigibody = GetComponent<Rigidbody>();
		TargetPosition = new Vector3(_target.transform.position.x, 0, _target.transform.position.z);
	}

	private void Update() {
		Move();

		RayPosition = new Vector3(transform.position.x, 0, transform.position.z);
    	RaycastHit hit;
   		Ray ray = new Ray(RayPosition, TargetPosition);
    	Physics.Raycast(ray, out hit);

    	if (hit.collider != null){

			if((transform.localScale.x - PlayerController.MinSize < PlayerController.MinimalCriticalSize) && hit.collider.tag.Equals("Enemy")){
				GameEvents.current.Lose();
			}
        Debug.DrawLine(ray.origin, hit.point, Color.red);
    	}
	}

	private void OnCollisionEnter(Collision other) {
		if(other.collider.CompareTag("Finish")){
			GameEvents.current.Win();
		}
		
		if(other.collider.CompareTag("Enemy")){
			GameEvents.current.Lose();
		}
	}
	private void Move(){
		_rigibody.velocity = new Vector3(_rigibody.velocity.x, _rigibody.velocity.y, _speed); 
	}
}
