using UnityEngine;

public class BetterJump : MonoBehaviour 
{
	public float FallMultiplier = 2.5f;
	public float LowJumpMulitiplier = 5f;

	Rigidbody2D rb;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
	{
		if (rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
		}
		else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
		{
            rb.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMulitiplier - 1) * Time.deltaTime;
		}
	}
}
