using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corde : MonoBehaviour
{

	public Transform[] points;

	private Vector3[] positions;
	public LineRenderer rope;

	public bool cut;

	public Collider col;

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

		print("touched");
		
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
		//trigers trap that kills the player
		print("TOUCHé");
		_player.GetComponentInParent<PlayerController>().Die();
	}
	
	void Trap()
	{
		//triggers trap that may not kill the player
		
		cut = true;
		rope.enabled = false;
	}
}
