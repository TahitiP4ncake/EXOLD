using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : MonoBehaviour
{

	public GameObject lance;

	public Transform lanceur;

	public GameObject fleche;

	public float lanceSpeed;
		
	public void Shoot(float _timer)
	{
		GameObject _lance = Instantiate(lance, lanceur.position, lanceur.rotation);
		
		_lance.GetComponent<Rigidbody>().velocity = lanceur.transform.up * lanceSpeed;
		
		print(lanceur.transform.forward);
		
		fleche.SetActive(false);
		Invoke("ShowArrow", _timer);
	}

	void ShowArrow()
	{
		fleche.SetActive(true);
	}
	
	
}
