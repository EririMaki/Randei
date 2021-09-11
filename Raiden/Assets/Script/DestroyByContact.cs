using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;

	//当其他碰撞器进入当前GameObject的触发器时，销毁该碰撞器对应的游戏对象，同时销毁该GameObject
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy" )//for enemy
		{
			return;
		}
		//enemy exp
		if(explosion!= null)
        {
			Instantiate(explosion, transform.position, transform.rotation);
		}

		//player exp
		if (other.tag == "Player" )//for player
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}

		//destroy animation
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
