using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDestroy : MonoBehaviour
{
	public GameObject BossExplosion;
	public int damage = 1;
	//Score when destroy
	//private int playerhp = game.life;
	private int bossHp;
	public int score;
	private GameController game;

	void Start()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GameController");
		game = go.GetComponent<GameController>();
		bossHp = 20;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")//for boss
		{
			bossHp = bossHp - damage;


			if (bossHp == 0)
			{
				Instantiate(BossExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);
				Destroy(gameObject);
				game.AddScore(score);
			}
			Destroy(other.gameObject);
		}

	}
}
