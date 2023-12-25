using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Rigidbody2D rigidbody2d;
    [SerializeField] GameObject DeadBackground;
    [SerializeField] GameObject InputField;

    
    [SerializeField] Animator animator;
    

    //JUMP
    [SerializeField] float JumpSpeed; 
    
    public bool Jumping;
    public bool DoubleJump;
    public bool isGrounded;

    //Movement
    [SerializeField] float velocity;
    [SerializeField] float baseVelocity;
    [SerializeField] float maxXVelocity = 100;
    [SerializeField] float maxAcceleration = 10;
    [SerializeField] float acceleration = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Accelerationnumber());
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Space) && DoubleJump == false)
        {
            rigidbody2d.velocity = new Vector2(velocity, rigidbody2d.velocity.y + JumpSpeed);

            if (acceleration > 2)
            {
                velocity--;
                acceleration--;
                animator.SetBool("Jumping" , true);
                animator.SetBool("Falling", false);
            }

            Jumping = true;
        }

        if (Jumping == true && Input.GetKeyDown(KeyCode.Space) && DoubleJump == false)
        {
            rigidbody2d.velocity = new Vector2(velocity, rigidbody2d.velocity.y + JumpSpeed/2);
            DoubleJump = true;
            animator.SetBool("Jumping", true);
            animator.SetBool("Falling", false);
        }

        if (rigidbody2d.velocity.y < -1)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);
        }

        if (rigidbody2d.velocity.y == 0)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        Jumping = false;
        DoubleJump = false;

       
        

        if (velocity < maxXVelocity)
        {
            velocity = baseVelocity  + acceleration;
        }
        else
        {
            velocity = maxXVelocity;
        }

        rigidbody2d.velocity = new Vector2(velocity, rigidbody2d.velocity.y);

        
    }

    IEnumerator Accelerationnumber()
    {
        if (acceleration < maxAcceleration)
        {
            yield return new WaitForSeconds(2.0f);
            acceleration++;
            StartCoroutine(Accelerationnumber());
        }
        
    }



}
