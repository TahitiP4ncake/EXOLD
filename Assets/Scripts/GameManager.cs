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

	private int goldInRoom;
	
	
	//INTRO

	public TextMeshProUGUI introText;

	public string intro;
	public string end;

	private bool isIntro = true;

	void Start()
	{
		blackScreen.color = Color.black;
		
		introText.text = intro;

		player.alive = false;
		
		Gold[] _golds = FindObjectsOfType<Gold>();


		goldInRoom = _golds.Length + 1;

		maxGoldAmount = goldInRoom;
		
		UpdateGoldAmount();
	}

	void Update()
	{
		if (isIntro)
		{
			if (Input.GetButtonDown("Gamepad_A"))
			{
				isIntro = false;
				introText.color = new Color(1,1,1,0);
				StartCoroutine(FadeOut());
			}
		}
	}
	

	IEnumerator FadeOut()
	{
		float _i = 1;

		Color _black = Color.black;
		while (_i > 0)
		{

			_black.a = _i;

			blackScreen.color = _black;
			

			_i -= Time.deltaTime;
			yield return null;
		}

		player.alive = true;
	}
	
	public void SetCheckpoint(Vector3 _position)
	{
		lastCheckpoint = _position;
		previousGoldAmount = goldAmount;
		
		golds.Clear();
		cutCordes.Clear();
	}
	


	public void Die(bool _rope = false)
	{
		StartCoroutine(Fade(_rope));
	}

	IEnumerator Fade(bool _instant = false)
	{
		float _i = 0;
		
		Color _black = new Color(0,0,0,_i);

		if (_instant == false)
		{

			while (_i < 1)
			{
				_i += Time.deltaTime;

				_black.a = _i;

				blackScreen.color = _black;

				yield return null;
			}
		}

		_black = Color.black;
		blackScreen.color = _black;

		_i = 1;

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
