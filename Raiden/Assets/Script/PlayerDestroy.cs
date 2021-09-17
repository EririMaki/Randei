using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
	public GameObject PlayerExplosion;

	//Score when destroy
	private GameController game;

	void Start()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GameController");
		game = go.GetComponent<GameController>();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")//for enemy
		{
			Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
			game.GameOver();
		}


		//player exp



		//destroy animation
		//Destroy(other.gameObject);
		//Destroy(gameObject);
	}
}
