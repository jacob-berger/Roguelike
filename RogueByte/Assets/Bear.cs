using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{

    Transform player;
    [SerializeField]
    Rigidbody2D rb;

    void Start()
    {
        this.health = 50;
        this.damage = 10;
        this.moveSpeed = 10f;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // animator.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);
        if (rb.position.x < player.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else 
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.position = Vector2.MoveTowards(rb.position, target, moveSpeed * Time.fixedDeltaTime);

    }

    public override void Attack()
    {

    }

    public override void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

    public override void DropLoot()
    {
        return;
    }
}
