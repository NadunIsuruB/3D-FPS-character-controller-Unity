using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 3f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    void Start()
    {
        controller.detectCollisions = false;
    }

    void Update()
    {
        
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float X = Input.GetAxis("Horizontal");
        float Y = Input.GetAxis("Vertical");


        if(Y > 0)
        {
            AnimationScript.instance.walk();
            if(speed != 0)
            {
                speed = 3f;
            }
            
        }
        else if(Y == 0)
        {
            AnimationScript.instance.idle();
        }

        if(Input.GetKey(KeyCode.LeftShift) && Y > 0)
        {
            if (speed != 0)
            {
                speed = 5f;
            }
            AnimationScript.instance.run();
        }

        Vector3 move = transform.right * X * Time.deltaTime + transform.forward * Y * Time.deltaTime;

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
            AnimationScript.instance.jump();
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(move * speed);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R) && Y == 0)
        {
            reload();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    private void reload()
    {
        StartCoroutine(StopForSometime());
        AnimationScript.instance.reload();
    }

    IEnumerator StopForSometime()
    {
        speed = 0;
        yield return new WaitForSeconds(3.42f);
        speed = 3;
    }
}
