using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultCanvasController : MonoBehaviour {
	[SerializeField] GameObject ResultPanel;
	[SerializeField] GameObject UIPanel;
	[SerializeField] Text ResultText;
	private void Start () {
		GameEvents.current.onWin += ShowWinnerPanel;
		GameEvents.current.onLose += ShowLoserPanel;
	}

	private void ShowWinnerPanel(){
		UIPanel.SetActive(false);
		ResultPanel.SetActive(true);
		ResultText.text = "You won!";
		Time.timeScale = 0f;
	}

	private void ShowLoserPanel(){
		UIPanel.SetActive(false);
		ResultPanel.SetActive(true);
		ResultText.text = "You lose!";
		Time.timeScale = 0f;
	}

	private void OnDisable() {
		GameEvents.current.onWin -= ShowWinnerPanel;
		GameEvents.current.onLose -= ShowLoserPanel;
	}
}
