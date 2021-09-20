using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
	public GameObject Bulletexplosion;
	//Score when destroy
	private GameController game;


	void Start()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GameController");
		game = go.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")//for enemy
		{
			return;
		}
		if (other.tag == "buff")
		{
			return;
		}

		if (other.tag == "Player")
		{
			

			Destroy(gameObject);
			
		}

	}
}
