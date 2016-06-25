using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

	public float smoothTimeX;
	public float smoothTimeY;

	public GameObject player;

	private Vector2 velocity;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3(posX, posY, transform.position.z);
	}
}
