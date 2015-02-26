﻿using UnityEngine;
using System.Collections;

public class DepositStates : MonoBehaviour {
	public GameObject box;
	public GameObject Player { get; set; }
	public string WeaponState { get; set; }
	private GameObject weapon;
	public PlayerStates myPlayerState; // used to access and change the players state
	public GameObject newWeapon;
	public GameObject spawn;

	public void SetWeapon(GameObject w)
	{
		weapon = w;
	}

	// Use this for initialization
	void Start () 
	{
		Player = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Player != null)
		{
			if(weapon != null)
			{
				WeaponState = weapon.GetComponent<ItemStates>().State;
			}
		}
		else
		{
			weapon = null;
			WeaponState = "NULL_STATE";

		}
		if(Input.GetMouseButton (1))
		{
			if(weapon != null)
			{
				if(WeaponState == "Good")
				{
					myPlayerState.points += 10;
					weapon.transform.position = new Vector3(box.transform.position.x, weapon.transform.position.y, box.transform.position.z);	//sets weapon above box
					weapon.transform.parent = null;
					weapon.GetComponent<Rigidbody>().isKinematic=false;
					Destroy (weapon, 1f);
					weapon = null;
					myPlayerState.RightHand = "Empty";
					Instantiate (newWeapon, spawn.transform.position, spawn.transform.rotation); 
				}
			}
		}
	}
}