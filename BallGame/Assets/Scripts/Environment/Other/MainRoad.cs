using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoad : MonoBehaviour {
	[SerializeField] private Transform _player;
	private readonly int _offsetX = 10; 
	private void Start () {
		GameEvents.current.onReducingRoad += ReducingScale;
	}
	private void ReducingScale(){
		transform.localScale = new Vector3(_player.localScale.x / _offsetX, transform.localScale.y, transform.localScale.z);
	}
	private void OnDisable() {
		GameEvents.current.onReducingRoad -= ReducingScale;
	}
}
