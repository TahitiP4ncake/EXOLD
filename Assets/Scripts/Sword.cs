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
		grabZone.enabled = false;
		rb.isKinematic = true;
		rb.useGravity = false;
		col.enabled = false;
	}

	public void HitWall()
	{
		rb.isKinematic = true;

		grabZone.enabled = true;
	}

	private void OnCollisionEnter(Collision other)
	{
		AudioSource _son = Harmony.SetSource("metalClang1");
		_son.pitch = Random.Range(.8f, 1.2f);
		_son.volume = .3f;
		Harmony.Play(_son);
		
		AudioSource _son2 = Harmony.SetSource("metalClang2");
		_son2.pitch = Random.Range(.8f, 1.2f);
		_son2.volume = .3f;
		Harmony.Play(_son2);

		
		if (other.collider.tag == "Wall")
		{
			HitWall();
		}
		else if (other.collider.tag == "Ground")
		{
			grabZone.enabled = true;
		}
	}
}
