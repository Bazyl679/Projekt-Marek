using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform playerPOS;
    [SerializeField] GameObject player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb2d;
    Vector2 startPos;

    [SerializeField] float attackDamage = 25f;
    [SerializeField] float attackSpeed = 1f;
    float canAttack;

    [SerializeField] int enemyHealth = 5;
    [SerializeField] int currentHealth;
    SpriteRenderer sprite;

    Score scoreEnemy;
    [SerializeField] int enemyScore = 20;
    [SerializeField] GameObject floatinPointsPrefab;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        startPos = transform.position;
        currentHealth = enemyHealth;
        scoreEnemy = FindObjectOfType<Score>();
        
    }


    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, playerPOS.position);

        if (distToPlayer < agroRange)
        {
            Follow();
        }
        else
        {
            transform.position = startPos;
        }

        if (transform.eulerAngles.z <= 90 || transform.eulerAngles.z >= 280)
        {
            sprite.flipY = false;
        }
        else if (transform.eulerAngles.z >= 90 || transform.eulerAngles.z > 280)
        {
            sprite.flipY = true;
        }
        rb2d.velocity = Vector2.zero;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                scoreEnemy.currentPoints += enemyScore;
                Instantiate(floatinPointsPrefab, transform.position, Quaternion.identity); ;
                Destroy(gameObject);
                
            }
        }
    }

    private void Follow()
    {
        Vector3 direction = playerPOS.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
}
