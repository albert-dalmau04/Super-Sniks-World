using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Invoke("PlayAgain" , 0.2f);
        }
    }


    private void PlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }
}
