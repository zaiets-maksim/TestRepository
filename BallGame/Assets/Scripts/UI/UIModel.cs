using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI{
public class UIModel : MonoBehaviour {}	
	interface IModelLayer{
		void OnClickButton(GameObject thisObj);
	}

    class PlayButton : IModelLayer{
        public void OnClickButton(GameObject thisObj)
        {   
        	SceneManager.LoadScene("Gameplay");
        }
    }

    class ExitButton : IModelLayer{
        public void OnClickButton(GameObject thisObj)
        {
            Application.Quit();
        }
    }

    class PauseButton : IModelLayer{
        public void OnClickButton(GameObject thisObj){
            GameEvents.current.Pause();
        }
    }

    class ResumeButton : IModelLayer{
        public void OnClickButton(GameObject thisObj){
            GameEvents.current.Resume();
        }
    }

    class MenuButton : IModelLayer{
        public void OnClickButton(GameObject thisObj)
        {   
            if(Time.timeScale == 0){
                Time.timeScale = 1f;
            }
            SceneManager.LoadScene("MainMenu");
        }
    }

        class RepeatButton : IModelLayer{
        public void OnClickButton(GameObject thisObj)
        {   
            if(Time.timeScale == 0){
                Time.timeScale = 1f;
            }
            SceneManager.LoadScene("Gameplay");
        }
    }
}
