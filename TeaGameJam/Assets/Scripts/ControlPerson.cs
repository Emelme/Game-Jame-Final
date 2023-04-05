using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlPerson : MonoBehaviour
{
    public Animator animator;
    private Vector2 direction;
    private Rigidbody2D rb; 
    public float runSpeed = 20.0f;
    public bool isMovable = true;

    //для отключения ходьбы FindObjectOfType<ControlPerson>().isMovable = false;

    private void Start()
    {    
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (isMovable)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            if (direction.x != 0) direction.y = 0;
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * runSpeed * Time.fixedDeltaTime);
    }


}
