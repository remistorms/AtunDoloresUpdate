using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ListaDePremios : MonoBehaviour {

	public BotonPremio[] buttons;

	void Start()
	{
		GetButtonsStatus ();
	}

	public void GetButtonsStatus()
	{
		for (int i = 0; i < GameSettings.instance.premios.Count; i++) 
		{
			for (int j = 0; j < buttons.Length; j++) 
			{

				Debug.Log (	GameSettings.instance.premios[i] + " compraring with..." + buttons[j].premio
				);
				if (GameSettings.instance.premios [i] == buttons [j].premio) 
				{
					buttons [j].transform.GetComponent<Button>().interactable = true;
					buttons [j].difficulty = GameSettings.instance.difficultades [i];
				} 
			}	
		}
	}

}
