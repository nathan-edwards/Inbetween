using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// jieying was here: make the result profile display craftable item details
public class CraftItemResultProfile : MonoBehaviour
{
	public CraftingRecipe recipe;
	public Transform profile;

    public void DisplayRecipeDetails(){
		//change UI from a "no selected item" state
		profile.GetComponent<Image>().color = new Color(1, 1, 1, 1);

		//change text to that of recipe result item name &
		//change text colour from a "no selected item" state
		profile.GetChild(0).GetComponent<Text>().text = recipe.result.itemName;
		profile.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Normal;
		profile.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);

		//change text to that of item description &
		//change text colour from a "no selected item" state
		profile.GetChild(1).GetComponent<Text>().text = recipe.result.itemDesc;
		profile.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);

		//make sprite visible
		//and change sprite to the selected item's sprite
		profile.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
		profile.GetChild(2).GetComponent<SpriteRenderer>().sprite = recipe.result.itemImg;

		//for every material needed to create the item, display the sprite of required material, name of required material
		//and how many of required material player has over (/) required number of material needed to craft item
		for(int i = 0; i < recipe.materials.Length; i++){
			//sprite
			profile.GetChild(3).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = recipe.materials[i].itemImg;
			profile.GetChild(3).GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

			//item name
			profile.GetChild(3).GetChild(i).GetChild(1).GetComponent<Text>().text = recipe.materials[i].itemName;
			profile.GetChild(3).GetChild(i).GetChild(1).GetComponent<Text>().enabled = true;

			//item materials
			profile.GetChild(3).GetChild(i).GetChild(2).GetComponent<Text>().text = (Inventory.inventory.SearchListForItemQuantity(recipe.materials[i])) + "/" + recipe.quantities[i];
			profile.GetChild(3).GetChild(i).GetChild(2).GetComponent<Text>().enabled = true;
		}

		//boolean variable to check if player has enough materials to craft item
		bool isCraftable = CheckIfHasEnoughMats(recipe.materials, recipe.quantities);
		
		//depending on wehether above variable is true or false, make the craft item button available to user
		if(isCraftable){
			//make the use item button clickable/interactable
			profile.GetChild(4).GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 1);
			profile.GetChild(4).GetComponent<Button>().interactable = true;
			profile.GetChild(4).GetComponent<CreateItem>().SetItem(recipe);
		} else {
			//make the use item button not clickable/interactable
			profile.GetChild(4).GetChild(0).GetComponent<Text>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5f);
			profile.GetChild(4).GetComponent<Button>().interactable = false;
		}
	}

	public void HideRecipeDetails(){
		//change UI back to a "no selected item" state
		profile.GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5f);

		//change text to default text &
		//change text colour back to "no selected item" state
		profile.GetChild(0).GetComponent<Text>().text = "Select an item to view it";
		profile.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Italic;
		profile.GetChild(0).GetComponent<Text>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5f);

		//change text to empty &
		//change text colour back to "no selected item" state
		profile.GetChild(1).GetComponent<Text>().text = "";
		profile.GetChild(1).GetComponent<Text>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5f);

		//hide sprite
		//and set sprite to no sprite
		profile.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
		profile.GetChild(2).GetComponent<SpriteRenderer>().sprite = null;
		
		//make the use item button not clickable/interactable
		profile.GetChild(3).GetChild(0).GetComponent<Text>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 0.5f);
		profile.GetChild(3).GetComponent<Button>().interactable = false;
	}

	//method to check if player has enough materials to craft item
	bool CheckIfHasEnoughMats(Item[] itemArr, int[] quantitiesArr){
		bool hasEnough = false;
		List<bool> meetsRequiredAmount = new List<bool>();

		//loop through required items and check inventory for quantity & compare with required amount
		//if enough, add true to list, otherwise add false
		for(int i = 0; i < itemArr.Length; i++){
			if(Inventory.inventory.SearchListForItemQuantity(itemArr[i]) >= quantitiesArr[i]){
				meetsRequiredAmount.Add(true);
			} else {
				meetsRequiredAmount.Add(false);
			}
		}

		//loop to check if player is missing any items
		//return false if just one material is not enough
		for(int i = 0; i < meetsRequiredAmount.Count; i++){
			if(!meetsRequiredAmount[i]){
				hasEnough = false;
				break;
			} else {
				hasEnough = true;
			}
		}

		return hasEnough;
	}
}
