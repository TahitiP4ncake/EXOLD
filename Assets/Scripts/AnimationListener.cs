using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationListener : MonoBehaviour {

	
	void Step()
	{
		AudioSource _son = Harmony.SetSource("step1");
		_son.pitch = Random.Range(.8f, 1.2f);
		Harmony.Play(_son);
	}
}
