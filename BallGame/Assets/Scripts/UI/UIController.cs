using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI{
public class UIController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
		private readonly string _namespaceName = "UI.";
		private Vector2 _buttonScale;
		public string GetСurrentNameObj { get { return this.gameObject.name; }}

    	public void OnPointerDown(PointerEventData eventData){
		Vibration.Vibrate(45);
        _buttonScale = new Vector2(this.transform.localScale.x, this.transform.localScale.y); 
    	this.transform.localScale = _buttonScale * 0.95f;
		}

    	public void OnPointerUp(PointerEventData eventData){
		this.transform.localScale = _buttonScale;
	    OnClick();
		}
		private void OnClick(){
			Type objType = Type.GetType(_namespaceName + GetСurrentNameObj);
			IModelLayer reflectionObj = Activator.CreateInstance(objType) as IModelLayer;
		
			if(reflectionObj != null) reflectionObj.OnClickButton(this.gameObject);
			// IModelLayer reflectionObj2 = new SettingsButton();
			// reflectionObj2.OnClickButton(this.gameObject);
	}
	}
}
