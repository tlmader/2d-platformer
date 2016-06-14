using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	[HideInInspector]
	public bool facingRight = true;
	[HideInInspector]
	public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;

	private bool grounded = false;
	private Animator animator;
	private Rigidbody2D body;

	// Use this for initialization
	void Awake()
	{
		animator = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Input.GetButtonDown("Jump")) // && grounded
			jump = true;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");

		animator.SetFloat("Speed", Mathf.Abs(h));

		if (h * body.velocity.x < maxSpeed)
			body.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs(body.velocity.x) > maxSpeed)
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * maxSpeed, body.velocity.y);

		if (h > 0 && !facingRight)
			Flip();
		else if (h < 0 && facingRight)
			Flip();

		if (jump)
		{
			animator.SetTrigger("Jump");
			body.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}