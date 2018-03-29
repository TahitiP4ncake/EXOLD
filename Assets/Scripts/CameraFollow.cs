using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform player;

	private Vector3 position;

	public float lerpSpeed;

	void FixedUpdate ()
	{
		position = player.position;

		position.y = 0;
		
		transform.position = Vector3.Lerp(transform.position,position , lerpSpeed);
	}
}
