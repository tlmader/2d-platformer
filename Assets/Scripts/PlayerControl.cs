using UnityEngine;
using System.Collections;

/**
 * This MonoBehaviour handles movement for the player character based on input.
 */
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
	public void Start()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
	}

	/**
	 * This function handles all regular updates for the player character.
	 */
	public void Update()
	{
		// Animator conditions
		animator.SetBool("Grounded", grounded);
		animator.SetFloat("Speed", Mathf.Abs(body.velocity.x));

		transform.localScale = GetDirection(Input.GetAxis("Horizontal"));

		// Jumping
		if (Input.GetButtonDown("Jump") && grounded)
			body.AddForce(GetJumpForce());
	}

	/**
	 * This function handles all physics updates for the player character.
	 */
	void FixedUpdate()
	{
		body.AddForce(GetForce(Input.GetAxis("Horizontal")));
		body.velocity = GetCappedVelocity();
	}

	/**
	 * This function returns a Vector2 used for Rigidbody2D.AddForce during horizontal movement.
	 */
	public Vector2 GetForce(float axis)
	{
		float h = axis;
		var v = (Vector2.right * speed) * h;
		var x = GetDirection(axis).x;
		// Prevent changing direction while midair
		if (!grounded && ((h > 0f && x < 0) || (h < 0f && x > 0f)))
			return body.velocity;
		return v;
	}

	/**
	 * This function returns a Vector2 used for Rigidbody2D.AddForce when jumping.
	 */
	public Vector2 GetJumpForce()
	{
		return Vector2.up * jumpPower;
	}

	/**
	 * This function returns a Vector2 used for Rigidbody2D.velocity, used to prevent movement speed above the defined max speed.
	 */
	public Vector2 GetCappedVelocity()
	{
		if (body.velocity.x > maxSpeed)
			return new Vector2(maxSpeed, body.velocity.y);
		if (body.velocity.x < -maxSpeed)
			return new Vector2(-maxSpeed, body.velocity.y);
		return body.velocity;
	}

	/**
	 * This function returns a Vector3 used for transform.localScale, used to adjust the sprite's direction based on input axis.
	 */
	public Vector3 GetDirection(float axis)
	{
		if (!grounded)
			return transform.localScale;
		if (axis < -0.1f)
			return new Vector3(-1, 1, 1);
		if (axis > 0.1f)
			return new Vector3(1, 1, 1);
		return transform.localScale;
	}

	/**
	 * This function returns the Rigidbody2D.
	 */
	public Rigidbody2D GetBody() {
		return body;
	}
}
