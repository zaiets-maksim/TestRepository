using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvasController : MonoBehaviour {

	[SerializeField] GameObject PausePanel;
	[SerializeField] GameObject PlayerControllerPanel;
	[SerializeField] GameObject PauseButton;
	private void Start () {
		GameEvents.current.onPause += ShowPanel;
		GameEvents.current.onResume += HidePanel;
	}
	private void ShowPanel(){
		PausePanel.SetActive(true);
		PlayerControllerPanel.SetActive(false);
		PauseButton.SetActive(false);
		if(Time.timeScale != 0){
			Time.timeScale = 0f;
		}
		
	}

	private void HidePanel(){
		PausePanel.SetActive(false);
		PlayerControllerPanel.SetActive(true);
		PauseButton.SetActive(true);
		if(Time.timeScale != 1){
			Time.timeScale = 1f;
		}
	} 

	private void OnDisable() {
		GameEvents.current.onPause -= ShowPanel;
		GameEvents.current.onResume -= HidePanel;
	}
}
