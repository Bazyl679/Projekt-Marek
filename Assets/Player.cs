using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float dashSpeed = 5f;
    [SerializeField] float actualMoveSpeed;
    [SerializeField] float dashDistance = 0.5f;
    [SerializeField] public float dashCooldown = 1f;
    float dashCounter;
    public float dashCoolCounter;
    TrailRenderer trail;


    Vector2 mosPos;
    Animator animator;
    SpriteRenderer spriteRenderer;

    float zRotation;

    Rigidbody2D rb2d;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        actualMoveSpeed = moveSpeed;
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        Movement();
        Direction();

        if (transform.hasChanged)
        {
            animator.Play("walk_animation");
        }
        else
        {
            animator.Play("player_idle");
        }
        transform.hasChanged = false;


        if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 280)
        {
            spriteRenderer.flipY = false;
        }
        else if (transform.eulerAngles.z >= 90 || transform.eulerAngles.z > 280)
        {
            spriteRenderer.flipY = true;
        }

        rb2d.velocity = Vector2.zero;
        
    }

    private void Update()
    {
        Dash();
    }

    private void Direction()
    {
        mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 look = new Vector2(mosPos.x - transform.position.x, mosPos.y - transform.position.y);
        transform.right = look;
    }

    private void Movement()
    {
        var zmianaX = Input.GetAxis("Horizontal") * Time.deltaTime * actualMoveSpeed;
        var zmianaY = Input.GetAxis("Vertical") * Time.deltaTime * actualMoveSpeed;

        var pozycjaX = transform.position.x + zmianaX;
        var pozycjaY = transform.position.y + zmianaY;

        transform.position = new Vector2(pozycjaX, pozycjaY);


    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                actualMoveSpeed = dashSpeed;
                dashCounter = dashDistance;
                trail.emitting = true;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                actualMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                trail.emitting = false;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }



}
