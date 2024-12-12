using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            
            Invoke("LoadLevel", 0.2f);
        }
    }


    private void LoadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }

    
}
