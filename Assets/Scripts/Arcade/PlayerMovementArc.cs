﻿using UnityEngine;

public class PlayerMovementArc : MonoBehaviour
{
    public float movementSpeed, jumpingForce;
    private bool isJumping;
    private float move;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject camObj;

    private Camera cam;
    float height;
    float width;

    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            jump();

        move = Input.GetAxisRaw("Horizontal") * movementSpeed * 7;
        animator.SetFloat("movement", move / movementSpeed * 7);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(move * Time.deltaTime, 0f, 0f);
    }


    private void jump()
    {
        if (!isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpingForce * rb.mass));
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            isJumping = false;
    }
}
