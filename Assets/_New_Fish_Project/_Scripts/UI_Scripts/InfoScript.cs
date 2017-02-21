using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour {

	[SerializeField] Text info_text ;


	public void ShowInfo(string info)
	{
		info_text.text = info;
	}
}
