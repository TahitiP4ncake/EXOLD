using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleche : MonoBehaviour
{

	public Rigidbody rb;


	
	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Wall")
		{
			Destroy(gameObject);
		}
		else if (other.collider.tag == "Sword")
		{
			Destroy(gameObject);
		}
	}
}
