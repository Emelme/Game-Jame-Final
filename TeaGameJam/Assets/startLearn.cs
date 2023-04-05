using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class startLearn : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Learn");
        }
    }


}
