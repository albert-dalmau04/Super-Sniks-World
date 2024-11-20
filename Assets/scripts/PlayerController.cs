using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb2d;

    private float Horizontal;

    public int speed;

    public int JumpForce;

    private bool isGrounded;

    private Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetBool("running", Horizontal != 0.0f);  //Amb això indiquem directament si el jugador s'està movent que faci l'animació

        if (Horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if ((Input.GetKeyDown("w") || (Input.GetKeyDown("up"))) && isGrounded)
        {

            Jump();

        }

        if (!isGrounded && rb2d.velocity.y > 0)
        {
            anim.SetBool("jumping", true);  
        }
        else
        {
            anim.SetBool("jumping", false);  
        }


    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Horizontal * speed, rb2d.velocity.y);

    }

    private void Jump()
    {
        rb2d.AddForce(Vector2.up * JumpForce);

    }
}
