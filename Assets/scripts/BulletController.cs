using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public AudioClip sound;

    public float speed;

    private Rigidbody2D rb2d;

    private Vector3 Direction;

    public GameObject bulletDestroyPrefab;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound, 0.8f); //amb aixo controlem el volum del audio que sonarà
    }

    private void FixedUpdate()
    {
        rb2d.velocity = Direction * speed;

    }

    public void SetDireccion(Vector3 direction)
    {
        Direction = direction;
    }

    private Vector3 destroyPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerController player = collision.GetComponent<PlayerController>();

        EnemyController enemy = collision.GetComponent<EnemyController>();

        BulletController bullet = collision.GetComponent<BulletController>();



        

        if (player != null)
        {
            player.Hit();
        }

        if (enemy != null)
        {
            enemy.Hit();
        }

        if (bullet != null)
        {
            return;     //amb aixo fem el 'break' de un for pero amb un if i surt de la funció
        }

        if (collision.CompareTag("moneda") || collision.CompareTag("paret"))
        {
            return;
        }

        DestroyBullet();
    }

    private void DestroyBullet()
    {
        destroyPosition = transform.position;
        Destroy(gameObject);

        Instantiate(bulletDestroyPrefab, destroyPosition, Quaternion.identity);
    }



}
