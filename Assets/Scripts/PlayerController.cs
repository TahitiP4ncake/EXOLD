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

	
	//INTERNALS
	public bool alive;
	
	private bool jumping;
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

	public GameObject sword;
	public float throwingSpeed;

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

	//throw sword
	void Throw()
	{
		
	}

	//Graw sword
	void Grab()
	{
		
	}

	public void Die()
	{
		
		alive = false;

		x = 0;
		z = 0;
		
		manager.Die();
	}

	void UpdateGravity()
	{
		gravity += Time.fixedDeltaTime;
		rb.velocity -= Vector3.up * gravity;
	}

	public void Respawn()
	{
		foreach (GameObject _arrow in arrows)
		{
				Destroy(_arrow);
		}

		alive = true;
		
		//anim.SetTrigger("Idle");
	}

	void OnCollisionEnter(Collision other)
	{
	
		if(other.collider.tag == "Lance")
		{
			Destroy(other.collider.gameObject.GetComponent<Rigidbody>());
			other.collider.gameObject.transform.SetParent(transform);
			arrows.Add(other.collider.gameObject);
			
			//attacher la lance au joueur et appliquer un ragdoll ?
			
			Die();
		}
		else if (other.collider.tag == "Spikes")
		{
			
			
			Die();
		}
	}

	private void OnCollisionStay(Collision other)
	{
		if (other.collider.tag == "Ground" && jumping)
		{
			jumping = false;
			gravity = 0;
		}
	}

	private void OnCollisionExit(Collision other)
	{
		jumping = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Sword")
		{
			Grab();
		}

		else if (other.tag == "Spike")
		{
			Die();
		}
		
	}
}
