using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tornado : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.06f, 0, 0);

        if (transform.position.x < -60) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "pickUp")
        {
            collision.gameObject.transform.position += new Vector3(Random.Range(-3, 2), Random.Range(0, 3), 0);
        }
    }
}
