using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

	public Collider grabZone;
	public Collider col;

	public Rigidbody rb;

	public void Throw()
	{
		
	}

	public void HitWall()
	{
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Wall")
		{
			HitWall();
		}
		else if (other.collider.tag == "Ground")
		{
			
		}
	}
}
