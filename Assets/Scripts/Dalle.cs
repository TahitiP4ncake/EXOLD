using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dalle : MonoBehaviour
{

	public Lance lance;

	private bool pushed;

	public float cooldown;

	public Animator anim;

	private Color _color;
	public Renderer rend;

	private void Start()
	{
		_color = GetComponent<Renderer>().material.color;
	}

	void OnTriggerEnter(Collider other)
	{
		if (!pushed)
		{
			if (other.tag != "Sword")
			{
				pushed = true;
				anim.SetTrigger("Push");
				//print("DALLE PUSHED");
				//rend.material.color = Color.white;
				
				AudioSource _son = Harmony.SetSource("trap2");
				_son.pitch = Random.Range(.8f, 1.2f);
				Harmony.Play(_son);

				
				lance.Shoot(cooldown);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Invoke("GetUp",cooldown);
	}

	void GetUp()
	{
		anim.SetTrigger("Up");
		
		//print("DALLE UP");
		rend.material.color = _color;
		pushed = false;
	}
}
