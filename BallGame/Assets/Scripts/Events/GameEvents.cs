using System;
using UnityEngine;

public class GameEvents : MonoBehaviour {
	public static GameEvents current;
	private void Awake (){
		current = this;
	}
	// public event Action<float> onShot;
	// // public event Action<float> onShot;
	// public void Shot(float scale){
	// 	if(onShot != null){
	// 		onShot(scale);
	// 	}
	// }
	public event Action onPause;
	public event Action onResume;
	// public event Action<GameObject, float, float, string> onZoomScale;
	public event Action onWin;
	public event Action onLose;
	public event Action onReducingRoad;
	// public event Action<float> onShot;
	// public void ZoomScale(GameObject ballChild, float newScale, float step, string log){
	// 	if(onZoomScale != null){
	// 		onZoomScale(ballChild, newScale, step, log);
	// 	}
	// }
	public void Pause(){
		if(onPause != null){
			onPause();
		}
	}

	public void Resume(){
		if(onResume != null){
			onResume();
		}
	}

		public void Win(){
		if(onWin != null){
			onWin();
		}
	}

		public void Lose(){
		if(onLose != null){
			onLose();
		}
	}
		public void ReducingRoad(){
		if(onReducingRoad != null){
			onReducingRoad();
		}
	}
	
}
