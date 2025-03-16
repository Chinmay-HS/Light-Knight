using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Animator animator;
	private float movement;
	public float moveSpeed = 5f;
	private bool facingRight = true;
	public Rigidbody2D rb;
	public float jumpHeight = 5f;

	private bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement < 0f && facingRight)
        {
	        transform.eulerAngles = new Vector3(0f, 180f, 0f);
	        facingRight = false;
        }
        else if (movement > 0f && facingRight == false)
        {
	        transform.eulerAngles = new Vector3(0f, 0f, 0f);
	        facingRight = true;
        }

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
	        Jump();
	        isGround = false;
	        animator.SetBool("Jump", true);
        }

        if (Mathf.Abs(movement) > .1f)
        {
	        animator.SetFloat("Run", 1f);
        }
        else if (movement < .1f)
        {
	        animator.SetFloat("Run", 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
	        animator.SetTrigger("Attack");
        }
        if (Input.GetMouseButtonDown(1))
        {
	        animator.SetTrigger("CombAttack");
        }
    }

	private void FixedUpdate()
	{
		transform.position += new Vector3(movement * moveSpeed * Time.fixedDeltaTime, 0f, 0f);
	}

	void Jump()
	{
			rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGround = true;
			animator.SetBool("Jump", false);
		}
	}
}