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
		
		AudioSource _son = Harmony.SetSource("money1");
		_son.pitch = Random.Range(.8f, 1.2f);
		Harmony.Play(_son);
		
		AudioSource _son2 = Harmony.SetSource("money2");
		_son2.pitch = Random.Range(.8f, 1.2f);
		Harmony.Play(_son2);
		
		//PlaySound;
	}

	public void ResetCoin()
	{
		//print("reset coin");
		rend.enabled = true;
		col.enabled = true;
	}
}
