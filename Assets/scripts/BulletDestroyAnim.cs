using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyAnim : MonoBehaviour
{
    public AudioClip sound;

    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sound, 0.3f);
    }
    private void DestroyBulletAnim()
    {
        Destroy(gameObject);
    }


}
