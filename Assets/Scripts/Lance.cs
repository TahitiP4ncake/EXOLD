using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{

	public GameObject lance;

	public Transform lanceur;

	public float lanceSpeed;
		
	public void Shoot()
	{
		GameObject _lance = Instantiate(lance, lanceur.position, lanceur.rotation);
		
		_lance.GetComponent<Rigidbody>().velocity = lanceur.transform.up * lanceSpeed;
		
		print(lanceur.transform.forward);
	}
	
	
}
