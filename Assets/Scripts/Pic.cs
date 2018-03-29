using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pic : MonoBehaviour
{

	public Animator anim;

	public Collider picCollider;

	public bool armed;

	private bool pushed;

	public float timeSpikeUp;
	
	public float cooldown;

	private void OnCollisionEnter(Collision other)
	{
		if (armed)
		{
			if (!pushed)
			{
				pushed = true;
				SpikeUp();
			}
		}
	}

	void SpikeUp()
	{
		//anim.SetTrigger("Pushed");
		print("SPIKES");
		picCollider.enabled = true;
		Invoke("SpikeDown",timeSpikeUp);
		
	}

	void SpikeDown()
	{
		//anim.SetTRigger("Down");
		print("DOWN");

		picCollider.enabled = false;
		
		Invoke("Ready", cooldown);
	}

	void Ready()
	{
		pushed = false;
	}
}
