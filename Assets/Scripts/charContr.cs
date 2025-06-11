using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;


public class CharContr : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    Vector2 movement;
    public Animator Anim;

    bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

         if (Input.GetButtonDown("Fire1"))
        {
            Anim.SetTrigger("attack");
                
        }   
        
    }

    private void FixedUpdate()
    {

        #region move
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);


        if (movement.y != 0 || movement.x != 0)
        {
            Anim.SetBool("isRunning", true);
        }
        else
        {
            Anim.SetBool("isRunning", false);
        }


        if (movement.x < 0 && facingRight)
        {
            flip();
            facingRight = !facingRight;
        }

        else if (movement.x > 0 && !facingRight)
        {
            flip();
            facingRight = !facingRight;
        }

        #endregion
    

    }

    void flip()
    {
        transform.Rotate(0, 180f, 0);
    }


}
