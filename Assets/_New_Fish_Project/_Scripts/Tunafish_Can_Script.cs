using UnityEngine;
using System.Collections;

public class Tunafish_Can_Script : MonoBehaviour {

	public Animator can_animator;
	public bool is_full = false;
	public int tuna_fish_pieces = 0;
	public bool has_something_inside = false;
	public bool can_grab = true;
	public GameObject lid_collider;

	public GameObject lid;
	public GameObject[] fish_pieces;
	public GameObject full_can, this_can;
	CanSounds can_sounds_ref;

	// Use this for initialization
	void Start () 
	{
		ResetCan ();
		can_sounds_ref = GetComponent<CanSounds> ();
	}

	public void AddFish()
	{
		switch (tuna_fish_pieces) 
		{
			case 0:
			can_sounds_ref.PlayBloop (0.5f);
			break;

			case 1:
			can_sounds_ref.PlayBloop (1.0f);
			break;

			case 2:
			can_sounds_ref.PlayBloop (1.5f);
			break;


		default:
			break;
		}
		if (tuna_fish_pieces < 2) 
		{
			fish_pieces [tuna_fish_pieces].SetActive (true);
			tuna_fish_pieces += 1;

		} 

		else 
		{
			//Fill can and do animation or something
			StartCoroutine(CloseCan());
		}

	}

	IEnumerator CloseCan()
	{
		can_grab = false;
		lid_collider.SetActive (true);
		fish_pieces [2].SetActive (true);
		yield return new WaitForSeconds (0.3f);
		lid.SetActive (true);
		//Do more stuff

		//Particles for filling up the can

		this_can.SetActive (false);
		GameObject cloned_can = Instantiate (full_can, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0))) as GameObject;
		can_sounds_ref.PlayBloop (2);
		yield return new WaitForSeconds(2.0f);
		ResetCan ();


	}

	public void RemoveFish()
	{
		foreach (var item in fish_pieces) {
			item.SetActive (false);
			tuna_fish_pieces = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Fish" && can_grab == true) 
		{
			GrowCan ();
			AddFish ();
			other.GetComponent<Fish_Script> ().ReturnToPool ();
		}

		if (other.tag == "Trash" && can_grab == true) 
		{
			GrowCan ();
			other.GetComponent<Fish_Script> ().ReturnToPool ();
			ResetCan ();
		}
	}

	public void ResetCan()
	{
		this_can.SetActive (true);
		lid.SetActive (false);
		foreach (var item in fish_pieces) 
		{
			item.SetActive (false);	
		}
		tuna_fish_pieces = 0;
		can_grab = true;
		lid_collider.SetActive (false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1)) 
		{
			AddFish ();
			REF.Instance.M_IO.TestSave ();
		}

		if (Input.GetKeyDown(KeyCode.Keypad0)) {
			RemoveFish ();
		}
	}

	public void GrowCan()
	{
		Debug.Log ("GrowCan");
		can_animator.SetTrigger ("GrowCan");
		//iTween.ScaleTo (this.gameObject, iTween.Hash ("scale", 3.0f, "time", 0.5f, "easetype", "linear", "looptype", iTween.LoopType.pingPong));
	}
		
}
