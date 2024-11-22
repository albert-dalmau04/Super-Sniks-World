using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb2d;

    private float Horizontal;

    public float speed;

    public int JumpForce;

    private bool isGrounded;

    private Animator anim;

    public GameObject bulletPrefab;

    public GameObject instantiateBullet;

    private float LastShoot;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetBool("running", Horizontal != 0.0f);  //Amb aix� indiquem directament si el jugador s'est� movent que faci l'animaci�

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

        if (Input.GetKey("space") && Time.time > LastShoot + 0.20f){

            Shoot();
            LastShoot = Time.time;
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

    private void Shoot()
    {

        Vector3 direction;

        if(transform.localScale.x == 1.0f)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        GameObject bullet = Instantiate(bulletPrefab, instantiateBullet.transform.position, Quaternion.identity);
        bullet.GetComponent<BulletController>().SetDireccion(direction);

        
    }
}
