using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private GameObject _shotBall;
	[SerializeField] private Transform _player;
	[Range(0, 5)]
	[SerializeField] private float _offsetZ;
	[SerializeField] private GameObject[] _balls = new GameObject[10];
	private float _scale;
	private static readonly float _minimalCriticalSize = 0.11f;
	private static readonly float _minSize = 0.13f;
	private static float _maxSize;
	
    public static float MinimalCriticalSize { get {return _minimalCriticalSize;}}
    public static float MinSize { get {return _minSize;}}
    public static float MaxSize { get {return _maxSize;} set { _maxSize = value; }}


    private void Start(){
		Init();
    }

	public void OnPointerDown(PointerEventData eventData){
		Vibration.Vibrate(70);
		Init();
		ProgressBarController.current.StartFillCircle();
	}

    public void OnPointerUp(PointerEventData eventData){
		Vibration.Vibrate(40);
		_scale = ProgressBarController.current.StopFillCircle();


		if((_player.localScale.x - MinSize) > MinimalCriticalSize && (_player.localScale.x - _scale) > MinimalCriticalSize && !_shotBall.activeInHierarchy){
			Shot(_scale);
			ReducingScale(_player.localScale.x, _scale);
			GameEvents.current.ReducingRoad();
		}
    }

	private void Init(){
		MaxSize = (_player.localScale.x);
		for(int i = 0; i < _balls.Length; i++){
			if(!_balls[i].activeInHierarchy){
				_shotBall = _balls[i];
			}
		}
	}

	private void Shot(float newScale){
				_shotBall.transform.position = new Vector3(_player.position.x, 0, _player.position.z + _offsetZ + newScale);
				_shotBall.transform.localScale = new Vector3(newScale, newScale, newScale);
				_shotBall.gameObject.SetActive(true);
	}

	private void ReducingScale(float currentScale, float ballСhildScale){
		float scale = currentScale - ballСhildScale;
		Vector3 targetScale = new Vector3(scale, scale, scale);
        _player.localScale = targetScale;
	}
}
