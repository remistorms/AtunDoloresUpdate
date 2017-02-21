using UnityEngine;
using System.Collections;

public class Manager_Position : Manager {

	public static Manager_Position instance;

	public Transform can_target_position;

	public void Initialize()
	{
		instance = this;
	}
}
