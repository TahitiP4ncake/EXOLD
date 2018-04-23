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
			AudioSource _son = Harmony.SetSource("arrow3");
			_son.pitch = Random.Range(.8f, 1.2f);
			Harmony.Play(_son);

			Destroy(gameObject);
		}
		else if (other.collider.tag == "Sword")
		{
			Destroy(gameObject);
		}
	}
}
