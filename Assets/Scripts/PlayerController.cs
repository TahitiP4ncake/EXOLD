using System.Collections;
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

	public GameObject sword;
	
	//INTERNALS

	private bool jumping;
	private bool armed;

	private float gravity;
	
	private Vector3 movement;
	private Vector3 direction;

	private float x;
	private float z;
	
	//MANAGER
	public GameManager manager;

	void Update()
	{

		if (Input.GetButtonDown("Gamepad_Start"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
		CheckInputs();
	}

	void FixedUpdate()
	{
		if (x != 0 || z != 0)
		{
			Turn();
			Move();
		}
		else
		{
			movement = Vector3.Lerp(movement, Vector3.zero, lerpSpeed);
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
		x = Input.GetAxis("Gamepad_Left_X") + Input.GetAxis("Horizontal");
		z = -Input.GetAxis("Gamepad_Left_Y") + Input.GetAxis("Vertical");

		if ((Input.GetButtonDown("Gamepad_A") || Input.GetKeyDown(KeyCode.Space)) && !jumping)
		{
			Jump();
		}

		if (Input.GetButtonDown("Gamepad_X") || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
		{
			Throw();
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

		rb.velocity += Vector3.up * jumpForce;
	}

	void Throw()
	{
		
	}

	void Grab()
	{
		
	}

	void Die()
	{
		manager.Die();
	}

	void UpdateGravity()
	{
		gravity += Time.fixedDeltaTime;
		rb.velocity -= Vector3.up * gravity;
	}

	public void Respawn()
	{
		anim.SetTrigger("Idle");
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Ground")
		{
			jumping = false;
			gravity = 0;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Sword")
		{
			Grab();
		}
	}
}
