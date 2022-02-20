using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    Transform playerPOS;
    [SerializeField] float moveSpeed = 1;
    Vector2 player;

    [SerializeField] float attackDamage = 25f;

    void Start()
    {
        playerPOS = GameObject.FindGameObjectWithTag("Player").transform;
        player = playerPOS.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, player, moveSpeed * Time.deltaTime);

        if (transform.position.x == player.x && transform.position.y == player.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            Destroy(gameObject);
        }

    }

}
