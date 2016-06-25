using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float maxSpeed = 3f;
	public float speed = 50f;
	public float jumpPower = 300f;

	public bool grounded;

	private Rigidbody2D body;
	private Animator animator;

	/**
	 * This function instantiates component objects used by this script.
	 */
	void Start()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
	}


	/**
	 * This function handles all regular updates for the player character.
	 */
	void Update()
	{
		// Animator conditions
		animator.SetBool("Grounded", grounded);
		animator.SetFloat("Speed", Mathf.Abs(body.velocity.x));

		// Adjusts sprite to movement along x-axis
		if (Input.GetAxis("Horizontal") < -0.1f)
			transform.localScale = new Vector3(-1, 1, 1);
		if (Input.GetAxis("Horizontal") > 0.1f)
			transform.localScale = new Vector3(1, 1, 1);

		// Jumping
		if (Input.GetButtonDown("Jump") && grounded)
			body.AddForce(Vector2.up * jumpPower);
	}

	/**
	 * This function handles all physics updates for the player character.
	 */
	void FixedUpdate()
	{
		// Movement
		float h = Input.GetAxis("Horizontal");
		body.AddForce((Vector2.right * speed) * h);

		// Cap velocity at max speed
		if (body.velocity.x > maxSpeed)
			body.velocity = new Vector2(maxSpeed, body.velocity.y);
		if (body.velocity.x < -maxSpeed)
			body.velocity = new Vector2(-maxSpeed, body.velocity.y);
	}
}
