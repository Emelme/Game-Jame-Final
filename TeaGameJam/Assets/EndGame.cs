using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool active;
    // Update is called once per frame
    void Update()
    {
        if(active && Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            active = false;
        }
    }
}
