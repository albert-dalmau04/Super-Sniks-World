using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlller : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.x > 0.35f && player.transform.position.x < 30.70f)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, offset.z);

        }
        
        
    }

    
}
