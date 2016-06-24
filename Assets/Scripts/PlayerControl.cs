using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float maxSpeed = 3f;
	public float speed = 50f;
	public float jumpPower = 150f;

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
		animator.SetBool("Grounded", grounded);
		animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if (Input.GetAxis("Horizontal") < 0.1f)
			transform.localScale = new Vector3(-1, 1, 1);
		if (Input.GetAxis("Horizontal") > 0.1f)
			transform.localScale = new Vector3(1, 1, 1);
	}

	/**
	 * This function handles all physics updates for the player character.
	 */
	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		body.AddForce((Vector2.right * speed) * h);

		if (body.velocity.x > maxSpeed)
			body.velocity = new Vector2(maxSpeed, body.velocity.y);
		if (body.velocity.x < -maxSpeed)
			body.velocity = new Vector2(-maxSpeed, body.velocity.y);
	}
}
