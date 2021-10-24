using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff_Skill : MonoBehaviour
{
	private GameController game;
	public int skillPoint = 1;
	void Start()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GameController");
		game = go.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			SkillController playerSkillControl = other.GetComponent<SkillController>();
			playerSkillControl.AddSkillNum(skillPoint);			
			Destroy(gameObject);
			return;
		}
	}	
}
