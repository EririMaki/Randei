using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Shield")//for shield
		{
			//Destroy(gameObject);
		}
	}

}
