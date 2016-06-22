using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float maxSpeed = 3f;
	public float speed = 50f;
	public float jumpPower = 150f;

	public bool grounded;

	private Rigidbody2D body;

	void Start()
	{
		body = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (body.velocity.x > maxSpeed)
			body.velocity = new Vector2(maxSpeed, body.velocity.y);
		if (speed < -maxSpeed)
			body.velocity = new Vector2(-maxSpeed, body.velocity.y);
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		body.AddForce((Vector2.right * speed) * h);
	}
}
