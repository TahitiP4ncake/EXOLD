﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public Rigidbody rb;

	public Animator anim;

	public GameObject cam;
	
	//Variables

	public float turnSpeed;
	public float speed;
	public float jumpForce;

	[Space] public float lerpSpeed;
	
	//OBJECT

	
	//INTERNALS
	public bool alive;
	
	public bool jumping;
	private bool armed;

	private float gravity;
	
	private Vector3 movement;
	private Vector3 direction;

	private float x;
	private float z;

	public List<GameObject> arrows;
	
	//MANAGER
	public GameManager manager;
	
	//THROWING SWORD
	[Space] public GameObject hand;

	public GameObject swordObject;
	public Sword sword;
	public float throwingSpeed;

	private Vector3 throwingDirection;

	public LayerMask cordeMask;
	
	//ANIMATIONS

	public bool walking;

	void Update()
	{

		if (Input.GetButtonDown("Gamepad_Start") || Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if (!alive)
		{
			return;
		}
		
		CheckInputs();
	}

	void FixedUpdate()
	{
		if (x != 0 || z != 0)
		{
			Turn();
			Move();

			if (!walking && !jumping)
			{
				//print("RUN");
				walking = true;
				anim.SetTrigger("Run");
			}
		}
		else
		{
			movement = Vector3.Lerp(movement, Vector3.zero, lerpSpeed);

			if (walking)
			{
				//print("Stop");
				walking = false;
				anim.SetTrigger("Stop");
			}
		}

		if (jumping)
		{
			UpdateGravity();
		}

		movement.y = rb.velocity.y;

		rb.velocity = movement;
	}

	void CheckInputs()
	{
		x = Input.GetAxis("Gamepad_Left_X") + Input.GetAxisRaw("Horizontal");
		z = -Input.GetAxis("Gamepad_Left_Y") + Input.GetAxisRaw("Vertical");

		if ((Input.GetButtonDown("Gamepad_A") || Input.GetKeyDown(KeyCode.Space)) && !jumping)
		{
			Jump();
		}

		if (Input.GetButtonDown("Gamepad_X") || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
		{
			if (armed)
			{
				Throw();
			}
		}
	}

	void Move()
	{
		movement = Vector3.Lerp(movement, transform.forward * Mathf.Clamp(Mathf.Abs(x) + Mathf.Abs(z), 0,1) * speed, lerpSpeed);
	}

	
	void Turn()
	{
		direction = new Vector3(0, Mathf.Atan2(z, -x) * 180 / Mathf.PI-90+cam.transform.eulerAngles.y, 0);

		float step = turnSpeed * Mathf.Abs (Mathf.DeltaAngle (transform.eulerAngles.y, direction.y))/180;
		//float step = turnSpeed;
		Quaternion turnRotation = Quaternion.Euler(0f, direction.y, 0f);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, turnRotation, step);
	}

	void Jump()
	{
		jumping = true;
		
		anim.SetTrigger("Jump");

		rb.velocity += Vector3.up * jumpForce;
	}

	//throw sword
	void Throw()
	{
		RaycastHit hit;

		
		if (Physics.Raycast(transform.position+ Vector3.up, transform.position+ Vector3.up + transform.forward, out hit, 4, cordeMask))
		{
			
			if (hit.collider.tag == "Corde")
			{
				print("corde");
				
				hit.collider.gameObject.GetComponentInParent<Corde>().Trap();
			}
		}
		
		PlaySound("Throw2");
		PlaySound("Voice1");
		
		anim.SetTrigger("Throw");
		walking = false;
		
		swordObject.transform.parent = null;
		armed = false;

		if (direction.y <= 45 && direction.y > -45)
		{
			throwingDirection = Vector3.forward;
		}
		else if (direction.y <= -45 && direction.y > -135)
		{
			throwingDirection = Vector3.left;
		}
		else if (direction.y <= -135 && direction.y > -225)
		{
			throwingDirection = Vector3.back;
		}
		else
		{
			throwingDirection = Vector3.right;
		}
		
		
		sword.Throw(transform.position + Vector3.up, throwingDirection*throwingSpeed);
	}

	//Graw sword
	void Grab(GameObject _sword)
	{
		if (sword == null)
		{
			sword = _sword.GetComponent<Sword>();
		}

		sword.Grab();

		armed = true;
		StartCoroutine(LerpSword());
	}

	IEnumerator LerpSword()
	{
		float _i = 0;

		Vector3 _position = swordObject.transform.position;
		Quaternion _rotation = swordObject.transform.rotation;
		
		while (_i < 1)
		{
			swordObject.transform.position = Vector3.Lerp(_position, hand.transform.position, _i);
			swordObject.transform.rotation = Quaternion.Slerp(_rotation, hand.transform.rotation, _i);
			_i += Time.deltaTime*10;
			yield return null;
		}
		
		swordObject.transform.SetParent(hand.transform);

		armed = true;
	}

	public void Die(bool _rope = false)
	{
		
		PlaySound("Voice1");
		
		alive = false;

		x = 0;
		z = 0;

		
		
		manager.Die(true);
	}

	void UpdateGravity()
	{
		gravity += Time.fixedDeltaTime;
		rb.velocity -= Vector3.up * gravity;
	}

	public void Respawn()
	{
		jumping = false;
		walking = false;
		
		foreach (GameObject _arrow in arrows)
		{
				Destroy(_arrow);
		}

		if (swordObject != null)
		{
			RespawnSword();
		}

		alive = true;
		
		//anim.SetTrigger("Idle");
	}

	void RespawnSword()
	{
		sword.Grab();

		swordObject.transform.position = hand.transform.position;
		swordObject.transform.rotation = hand.transform.rotation;
		
		swordObject.transform.SetParent(hand.transform);

		
		armed = true;
	}
	
	void OnCollisionEnter(Collision other)
	{
	
		if(other.collider.tag == "Lance")
		{
			Destroy(other.collider.gameObject.GetComponentInParent<Rigidbody>());
			other.collider.transform.parent.SetParent(transform);
			arrows.Add(other.collider.transform.parent.gameObject);
			
			//attacher la lance au joueur et appliquer un ragdoll ?
			
			Die();
		}
		else if (other.collider.tag == "Spikes")
		{
			Die();
		}


		if (jumping)
		{
			if (x != 0 || z != 0)
			{
				walking = true;
				anim.SetTrigger("Run");
				jumping = false;
				gravity = 0;
			}
			else
			{
				walking = false;
				anim.SetTrigger("Stop");
				jumping = false;
				gravity = 0;
			}
		}
//		else if (other.collider.tag == "Sword")
//		{
//			if (swordObject == null)
//			{
//				swordObject = other.transform.parent.transform.parent.gameObject;
//			}
//			Grab(swordObject);
//		}
	}
/*
	private void OnCollisionStay(Collision other)
	{
		if (other.collider.tag == "Ground" && jumping)
		{
			jumping = false;
			gravity = 0;

			
		}
	}
*/
	private void OnCollisionExit(Collision other)
	{
		//jumping = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Sword")
		{
			if (swordObject == null)
			{
				swordObject = other.transform.parent.transform.parent.gameObject;
				
			}
			PlaySound("Throw3");
			Grab(swordObject);
		}

		else if (other.tag == "Spike")
		{
			Die();
		}
		else if (other.tag == "Gold")
		{
		}
		else if (other.tag == "Spikes")
		{
			Die();
		}
		
	}

	void PlaySound(string _clip)
	{
		AudioSource _son = Harmony.SetSource(_clip);
		_son.pitch = Random.Range(.8f, 1.2f);
		Harmony.Play(_son);
	}
}
