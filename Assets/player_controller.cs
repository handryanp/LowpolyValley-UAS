using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    float speed = 4;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 8;
    float jump = 5f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController> ();
        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        Movement ();
        GetInput ();
    }

    void Movement()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
                if(anim.GetBool("attacking") == true)
                {
                    return;
                }
                else if (anim.GetBool("attacking") == false)
                {
                anim.SetBool ("running", true);
                anim.SetInteger ("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
                }
            }

            if(Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool ("running", false);
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

            if(Input.GetKey(KeyCode.Space))
            {
                anim.SetBool ("jump", true);
                anim.SetInteger ("condition", 3);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move (moveDir * Time.deltaTime);
    }

    void GetInput()
    {
        if (controller.isGrounded)
        {
            if (Input.GetMouseButtonDown (0))
            {
                if(anim.GetBool("running") == true)
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("condition", 0);
                }
                if (anim.GetBool("running") == false)
                {
                    Attacking();
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                anim.SetBool ("jump", false);
                anim.SetInteger ("condition", 0);
            }
        }
    }

    void Attacking()
    {
        StartCoroutine (AttackRoutine());
    }

    void Jump()
    {
        StartCoroutine (JumpRoutine());
    }

    IEnumerator AttackRoutine()
    {
        anim.SetBool("attacking", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds (1);
        anim.SetInteger("condition", 0);
        anim.SetBool("attacking", false);
    }

    IEnumerator JumpRoutine()
    {
        anim.SetBool ("jump", true);
        anim.SetInteger ("condition", 3);
        yield return new WaitForSeconds (3);
        anim.SetInteger ("condition", 0);
        anim.SetBool ("jump", false);
    }
}
