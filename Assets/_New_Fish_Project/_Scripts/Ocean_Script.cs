using UnityEngine;
using System.Collections;

public class Ocean_Script : MonoBehaviour {

	public float move_speed = 0.5f;
	public float wave_time = 5f;
	public Vector2 water_direction;
	public MeshRenderer ocean_renderer;
	Vector2 offset_vector;

	public bool has_morphs = false;

	// Use this for initialization
	void Start () 
	{
		if (has_morphs) {
			ocean_renderer = GetComponent<MeshRenderer> ();
			WaveMorphs ();
		} 
		else 
		{
			ocean_renderer = GetComponent<MeshRenderer> ();
		}

	}

	void Update()
	{
		OffsetOceanTexture ();
	}

	void WaveMorphs()
	{
		iTween.ValueTo (this.gameObject, iTween.Hash ("from", 0, "to", 100, "time", wave_time, "onupdatetarget", this.gameObject, "onupdate", "UpdateMorphValue", "looptype", iTween.LoopType.pingPong));
	}

	void OffsetOceanTexture()
	{
		offset_vector = water_direction * Time.time * move_speed * 0.01f;
		ocean_renderer.material.SetTextureOffset ("_MainTex", offset_vector);
	}

	public void UpdateMorphValue(float new_value)
	{
	//	ocean_renderer.SetBlendShapeWeight (0, new_value);
	}

}
