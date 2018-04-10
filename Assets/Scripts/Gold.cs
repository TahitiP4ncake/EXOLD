using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

	public Renderer rend;
	public Collider col;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<GameManager>().GetGold(this);
			
			PickedUp();
		}
	}

	void PickedUp()
	{
		rend.enabled = false;
		col.enabled = false;
		
		//PlaySound;
	}

	public void ResetCoin()
	{
		//print("reset coin");
		rend.enabled = true;
		col.enabled = true;
	}
}
