using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{

    Transform player;
    [SerializeField]
    Rigidbody2D rb;
    IEnumerator attackRoutine;
    Vector2 target;
    int cooldown;
    bool hasAttacked;

    void Start()
    {
        this.health = 50;
        this.damage = 10;
        this.moveSpeed = 10f;
        // attackRoutine = Attack();
        cooldown = 3;
        hasAttacked = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // animator.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
        hasAttacked = false;
    }

    public override void Move()
    {
        target = new Vector2(player.position.x, player.position.y);
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

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // StartCoroutine(attackRoutine);
            StartCoroutine(Attack());
        }
    }

    public override IEnumerator Attack()
    {
        Debug.Log("Attacking");
        this.moveSpeed = 15f;
        transform.position = Vector2.MoveTowards(rb.position, target, -1 * moveSpeed * Time.fixedDeltaTime);
        // for (int ix = 1000; ix > 0; ix--);
        yield return new WaitForSeconds(10f);
        this.moveSpeed = 10f;
        hasAttacked = true;
        Debug.Log("Finished");
        // yield return null;
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
