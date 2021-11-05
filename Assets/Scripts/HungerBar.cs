using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: making hunger bar UI change according to player hunger
public class HungerBar : MonoBehaviour
{
	//image used to make hunger bar in unity
	public Image img;
	public static HungerBar instance { get; private set;}

	//store instance of hunger bar of scene
	void Awake(){
		instance = this;
	}

	public void updateHungerBar(float x){
		//change size of current hunger bar according to starvation or food item
		img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x);
	}
}
