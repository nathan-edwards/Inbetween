using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jay was here: making health bar UI change according to player health
public class HealthBar : MonoBehaviour
{
	//image used to make health bar in unity
	public Image img;
	public static HealthBar instance {get; private set;}

	//store instance of health bar of scene
	void Awake(){
		instance = this;
	}

	public void updateHealthBar(float x){
		//change size of current health bar according to damage or healing item
		img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
	}
}
