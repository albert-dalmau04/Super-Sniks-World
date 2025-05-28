using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    private int Health = 10;  //trets que aguanta el jugador

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

        if ((Input.GetKeyDown("w") || (Input.GetKeyDown("up"))) && isGrounded)
        {

            Jump();
            

        }

        if (Input.GetKey("space") && Time.time > LastShoot + 0.20f)
        {

            Shoot();
            LastShoot = Time.time;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("terra") || collision.gameObject.CompareTag("enemy"))
        {
            isGrounded = true;
        }

        
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("terra") || collision.gameObject.CompareTag("enemy"))
        {
            isGrounded = false;
        }

        
    }

    public void Hit()
    {
        Health--;

        if (Health == 0)
        {

            gameObject.SetActive(false);  //desactivem el personatje per fer l'efecte de que l'han matat

            Invoke("GameOver", 0.5f);

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

            if (transform.localScale.x == 1.0f)
            {
                direction = Vector3.right;
            }
            else
            {
                direction = Vector3.left;
            }

            GameObject bullet = Instantiate(bulletPrefab, instantiateBullet.transform.position, Quaternion.identity);
            bullet.GetComponent<BulletController>().SetDireccion(direction);

            Destroy(bullet, 5f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("background"))
        {
            Invoke("GameOver", 0.2f);
        }

        if (collision.gameObject.CompareTag("moneda"))
        {
            Invoke("YouWin", 0.2f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void YouWin()
    {
        SceneManager.LoadScene("YouWin");
    }

}
