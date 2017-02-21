using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS : MonoBehaviour {

	public bool show_fps = true;
	float deltaTime = 0f;
	float fps;
	public Text fps_label;

	// Update is called once per frame
	void Update () 
	{
		if (show_fps) 
		{
			deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
			fps = 1 / deltaTime;
			fps_label.text = fps.ToString("F1") + " FPS";
		}

	}
}
