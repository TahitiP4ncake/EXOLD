using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corde : MonoBehaviour
{

	//public Transform[] points;

	//private Vector3[] positions;
	//public LineRenderer rope;

	public bool cut;

	public Collider col;

	public Renderer rend;


	public Animator anim;
//	private void Start()
//	{
//		positions = new Vector3[points.Length];
//	}
//
//	void Update()
//	{
//		if (!cut)
//		{
//			UpdatePositions();
//			DrawLine();
//		}
//	}
//
//	void UpdatePositions()
//	{
//		for (int i = 0; i < points.Length; i++)
//		{
//			positions[i] = points[i].position;
//		}
//	}
//	
//	void DrawLine()
//	{
//		rope.SetPositions(positions);
//	}

	private void OnTriggerEnter(Collider other)
	{		
		if (other.GetComponent<Collider>().tag == "Player")
		{			
			KillPlayer(other.GetComponent<Collider>().gameObject);
			
		}
		else if (other.GetComponent<Collider>().tag == "Sword" || other.GetComponent<Collider>().tag=="Lance")
		{
			col.enabled = false;	
			Trap();
		}

		
	}

	void KillPlayer(GameObject _player)
	{
		AudioSource _son = Harmony.SetSource("trap1");
		_son.pitch = Random.Range(.8f, 1.2f);
		Harmony.Play(_son);

		
		//trigers trap that kills the player
		_player.GetComponentInParent<PlayerController>().Die();
	}
	
	void Trap()
	{
		
		AudioSource _son = Harmony.SetSource("arrow2");
		_son.pitch = Random.Range(.8f, 1.2f);
		Harmony.Play(_son);

		//triggers trap that may not kill the player
		FindObjectOfType<GameManager>().CutCorde(this);
		anim.SetTrigger("Cut");
		
		cut = true;
		rend.enabled = false;
		
		//Destroy(gameObject);
		//rope.enabled = false;
	}

	public void ResetTrap()
	{
		anim.SetTrigger("On");
		cut = false;
		rend.enabled = true;
		col.enabled = true;

	}
}
