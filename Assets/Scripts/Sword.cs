using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

	public Collider grabZone;
	public Collider col;

	public Rigidbody rb;

	public void Throw(Vector3 _direction)
	{
		rb.isKinematic = false;
		rb.useGravity = true;
		col.enabled = true;
		rb.velocity = _direction;
		transform.LookAt(transform.position + _direction);
		rb.AddTorque(transform.right * _direction.magnitude, ForceMode.VelocityChange);
	}

	public void Grab()
	{
		rb.isKinematic = true;
		rb.useGravity = false;
		col.enabled = false;
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
