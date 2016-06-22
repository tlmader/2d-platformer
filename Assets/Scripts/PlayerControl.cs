using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
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

	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		body.AddForce((Vector2.right * speed) * h);
	}
}
