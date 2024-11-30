using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;

    private Vector3 Direction;

    public GameObject bulletDestroyPrefab;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        if(player != null)
        {
            player.Hit();
        }

        if(enemy != null)
        {
            enemy.Hit();
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
