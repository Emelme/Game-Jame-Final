using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public GameObject toAnim;
    public bool load;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!load)
            {
                toAnim.SetActive(true);
                Destroy(gameObject);
            }
            else SceneManager.LoadScene(3);
        }
    }
}
