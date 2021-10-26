using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayerDestroy : MonoBehaviour
{
	public GameObject PlayerExplosion;
	public int damage = 1;
	public int newbomb = 1;
	//Score when destroy
	private TutorialController game;
	//private int playerhp = game.life;
	private int playerhp;

	void Start()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GameController");
		game = go.GetComponent<TutorialController>();
		playerhp = game.life;
	}
}
