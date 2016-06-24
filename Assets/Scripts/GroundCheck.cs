using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private PlayerControl player;

	void Start () {
		player = gameObject.GetComponentInParent<PlayerControl>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		player.grounded = false;
	}
}
