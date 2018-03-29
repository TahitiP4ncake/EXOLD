using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dalle : MonoBehaviour
{

	public Lance lance;

	private bool pushed;

	public float cooldown;

	public Animator anim;
	
	void OnTriggerEnter(Collider other)
	{
		if (!pushed)
		{
			pushed = true;
			//anim.SetTrigger("Push");
			print("DALLE PUSHED");
			lance.Shoot();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Invoke("GetUp",cooldown);
	}

	void GetUp()
	{
		//anim.SetTrigger("Up");
		
		print("DALLE UP");
		
		pushed = false;
	}
}
