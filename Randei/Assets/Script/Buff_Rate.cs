using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Rate : MonoBehaviour
{
	//Score when destroy
	private GameController game;

	void Start()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GameController");
		game = go.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player")
		{
			PlayerController player = other.GetComponent<PlayerController>();
			player.AddFireRate();
			//player.isBuffed();
			//player.isMultipleBuff();
			Destroy(gameObject);
			return;
		}
	}
}
