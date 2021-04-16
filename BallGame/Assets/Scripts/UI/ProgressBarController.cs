using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour {
	public static ProgressBarController current;
	private float _progress;
	private Slider _progressBar;
	private readonly float _step = 0.01f;
	private void Awake (){
		current = this;
	}

	private void Start() {
		_progressBar = GetComponent<Slider>();
		_progressBar.minValue = PlayerController.MinSize;
		InitValueSlider();
	}
	private void InitValueSlider(){
		_progressBar.value = PlayerController.MinSize;

		if(PlayerController.MaxSize < PlayerController.MinimalCriticalSize + PlayerController.MinSize){
			_progressBar.maxValue = PlayerController.MaxSize;
		}else{
			_progressBar.maxValue = PlayerController.MaxSize - PlayerController.MinimalCriticalSize;
		}
	}

	public void StartFillCircle(){
		_progress = 0f;
		InitValueSlider();
		if (Input.touchCount > 0) {
        Touch touch = Input.GetTouch(0);
        	if(touch.phase == TouchPhase.Began) {
				StartCoroutine(IncrementProgress());
        	}
		}
	}

	public float StopFillCircle(){
		if (Input.touchCount > 0) {
        Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Ended) {
				StopAllCoroutines();
			}
		}
		return CheckState();
	}

	private float CheckState(){
		if(_progress < _progressBar.minValue){
			_progressBar.value = PlayerController.MinSize;
			return PlayerController.MinSize;
	
		}else if(_progress > PlayerController.MaxSize - PlayerController.MinimalCriticalSize){
			GameEvents.current.Lose();
			return PlayerController.MaxSize - PlayerController.MinimalCriticalSize;
		}
		_progressBar.value = _progress;
		return _progress;
	}

	private IEnumerator IncrementProgress(){
		_progress = _progressBar.value += _step;
		yield return null;
		StartCoroutine(IncrementProgress());
	}
}
