using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    Vector3 dir;

    public float speed = 2f;
    bool isMove;
    float rotatedspeed = 5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        dir = new Vector3(h, 0, v) * speed;

        if (dir != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime*rotatedspeed);
            animator.SetBool("isMove", true);
        }

        controller.Move(dir*Time.deltaTime);
    }

    void Attack()
    {
        animator.SetTrigger("isAttack");
    }
}
