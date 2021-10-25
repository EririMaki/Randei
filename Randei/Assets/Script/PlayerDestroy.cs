using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
	public GameObject PlayerExplosion;
	public int damage = 1;
	public int newbomb = 1;
	//Score when destroy
	private GameController game;
	//private int playerhp = game.life;
	private int playerhp;

	void Start()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GameController");
		game = go.GetComponent<GameController>();
		playerhp = game.life;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			game.getHP(damage);
			playerhp = playerhp - damage;
			

			if (playerhp == 0)
			{
				Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);
				Destroy(gameObject);
				game.GameOver();
			}
			Destroy(other.gameObject);
		}
		if (other.tag == "Boss")
        {
			game.getHP(damage);
			playerhp = playerhp - damage;


			if (playerhp == 0)
			{
				Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);
				Destroy(gameObject);
				game.GameOver();
			}
		}
	}
}
