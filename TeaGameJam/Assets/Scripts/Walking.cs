using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public Animator animator;
    private Vector2 direction;
    private Rigidbody2D rb;
    public float runSpeed = 20.0f;
    public bool isMovable = true;
    public SpriteRenderer sprite;

    public bool isOpen = false;
    public GameObject guide;
    public GameObject walkSound;
    //для отключения ходьбы FindObjectOfType<ControlPerson>().isMovable = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOpen = !isOpen;
            guide.SetActive(isOpen);
        }
        if (isMovable)
        {
            
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            if (direction.x != 0 || direction.y != 0)
            {
                if (direction.x > 0)
                {
                    walkSound.SetActive(true);
                    sprite.flipX = false;

                }
                

                if (direction.x < 0)
                {
                    walkSound.SetActive(true);
                    sprite.flipX = true;
                }
                if(direction.y == 0 && direction.x == 0) walkSound.SetActive(false);
                animator.SetBool("isWalking", true);
            }
            else
            {
                walkSound.SetActive(false);
                animator.SetBool("isWalking", false);
            }

        }

        else
        {
            animator.SetBool("isWalking", false);
            walkSound.SetActive(false);
        }
        
    }

    void FixedUpdate()
    {
        if (isMovable) rb.MovePosition(rb.position + direction * runSpeed * Time.fixedDeltaTime);
        
        
    }

}
