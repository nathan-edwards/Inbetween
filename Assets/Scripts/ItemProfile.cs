using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: creating a script for item details
public class ItemProfile : MonoBehaviour
{
	//item to display details of
	public Item item;
	//the UI to display details with/on
	public Transform profile;

	public void DisplayItemDetails(){
		//change UI from a "no selected item" state
		profile.GetComponent<Image>().color = new Color(1, 1, 1, 1);

		//change text to that of item name &
		//change text colour from a "no selected item" state
		profile.GetChild(0).GetComponent<Text>().text = item.itemName;
		profile.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);

		//change text to that of item description &
		//change text colour from a "no selected item" state
		profile.GetChild(1).GetComponent<Text>().text = item.itemDesc;
		profile.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);

		//make sprite visible
		//and change sprite to the selected item's sprite
		profile.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
		profile.GetChild(2).GetComponent<SpriteRenderer>().sprite = item.itemImg;
		
		//make the use item button clickable/interactable
		profile.GetChild(3).GetComponent<Button>().interactable = true;
	}
}
