using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHunt : MonoBehaviour
{
    public float speed = 5f;
    public Transform player;
    public SpriteRenderer sprite;
    private ResManager res;

    void Awake()
    {
        player = FindObjectOfType<ResManager>().player.transform;
        sprite = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {    
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed);
        if (transform.position.x - player.position.x < 0) sprite.flipX = true;
        else sprite.flipX = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            res = FindObjectOfType<ResManager>();
            if (res.water >= 1) res.water -= 1;
            if (res.water < 1 && res.food >= 1) res.food -= 1;
        }
    }
}
