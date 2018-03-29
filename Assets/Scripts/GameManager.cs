using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Vector3 lastCheckpoint;

	public PlayerController player;
	
	//UI

	[Space] public Image blackScreen;
	
	public void Checkpoint()
	{
		lastCheckpoint = player.transform.position;
	}

	public void Die()
	{
		StartCoroutine(Fade());
	}
	
	IEnumerator Fade()
	{
		float _i = 0;
		
		Color _black = new Color(0,0,0,_i);

		while (_i < 1)
		{
			_i += Time.deltaTime;
			
			_black.a = _i;
			
			blackScreen.color = _black;

			yield return null;
		}

		player.transform.position = lastCheckpoint;
		player.Respawn();
		
		yield return new WaitForSecondsRealtime(.5f);

		while (_i > 0)
		{
			_i -= Time.deltaTime;
			
			_black.a = _i;
			
			blackScreen.color = _black;

			yield return null;	
		}
		
	}
	
}
