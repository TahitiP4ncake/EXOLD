using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public Vector3 lastCheckpoint;

	public PlayerController player;

	private List<Corde> cutCordes = new List<Corde>();

	[Space] public int goldAmount;

	private int previousGoldAmount;

	public int maxGoldAmount;

	private List<Gold> golds = new List<Gold>();

	//UI

	[Space] public Image blackScreen;

	public TextMeshProUGUI goldText;

	void Start()
	{
		UpdateGoldAmount();
	}


	public void SetCheckpoint(Vector3 _position)
	{
		lastCheckpoint = _position;
		previousGoldAmount = goldAmount;
		
		golds.Clear();
		cutCordes.Clear();
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

		ResetTraps();
		
		yield return new WaitForSecondsRealtime(.5f);

		while (_i > 0)
		{
			_i -= Time.deltaTime;
			
			_black.a = _i;
			
			blackScreen.color = _black;

			yield return null;	
		}
		
	}

	void ResetTraps()
	{
		foreach (Corde _corde in cutCordes)
		{
			_corde.ResetTrap();
		}

		foreach (Gold _gold in golds)
		{
			_gold.ResetCoin();
		}
		
		golds.Clear();
		
		cutCordes.Clear();

		goldAmount = previousGoldAmount;

		UpdateGoldAmount();
	}

	public void GetGold(Gold _gold)
	{
		goldAmount++;
		golds.Add(_gold);

		UpdateGoldAmount();
	}

	void UpdateGoldAmount()
	{
		goldText.text = goldAmount + "/" + maxGoldAmount;
	}

	public void CutCorde(Corde _corde)
	{
		cutCordes.Add(_corde);
	}
}
