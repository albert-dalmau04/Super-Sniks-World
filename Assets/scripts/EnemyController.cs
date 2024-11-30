using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject player;

    public GameObject bulletPrefab;

    public GameObject instantiateBullet;

    private float LastShoot;

    private float distance;

    private int Health = 33;

    void Update()
    {

        if(player != null)
        {
            Vector3 direction = player.transform.position - transform.position;

            if (direction.x > 0.0f)
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else if (direction.x < 0.0f)
            {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            }

            distance = Mathf.Abs(player.transform.position.x - transform.position.x);  //amb aixo fem que sempri ens doni un resultat positiu per saber el valor de la distancia

            if (distance < 1.0f && Time.time > LastShoot + 0.30f)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }
        
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
    }

    public void Hit()
    {
        Health--;
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }


}
