using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public LayerMask GroundLayer;

	bool canJump = true;

	[SerializeField]
	float Speed = 10f;

	[SerializeField][Range(0, 10)]
	float JumpVelocity;

	Rigidbody2D rb;

	void Start () 
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		canJump = gameObject.GetComponent<BoxCollider2D>().IsTouchingLayers(GroundLayer);
		transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0f, 0f, Space.World);
	}

	void FixedUpdate ()
	{
		if (Input.GetButtonDown("Jump") && canJump)
		{
			rb.velocity = Vector2.up * JumpVelocity;
		}
	}
}
