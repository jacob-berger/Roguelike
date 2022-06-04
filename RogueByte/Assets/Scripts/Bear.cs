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
    int cooldown = 2;
    bool isAttacking = false;
    float savedTime;

    void Start()
    {
        this.health = 50;
        this.damage = 10;
        this.moveSpeed = 10f;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        // animator.GetComponent<Rigidbody2D>();

        savedTime = Time.time;
    }

    void FixedUpdate()
    {
        target = new Vector2(player.position.x, player.position.y);
        Move();

    }

    public override void Move()
    {
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
            
            if (Time.time - savedTime >= cooldown)
            {
                StartCoroutine(Attack());
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //
        }
    }

    public override IEnumerator Attack()
    {
        isAttacking = true;
        Debug.Log("Attacking");
        //back up
        this.moveSpeed = -8f;
        yield return new WaitForSeconds(2f);

        //delay
        this.moveSpeed = 0;
        yield return new WaitForSeconds(.5f);

        //charge
        this.moveSpeed = 20f;
        yield return new WaitForSeconds(1f);

        this.moveSpeed = 10f;
        isAttacking = false;
        savedTime = Time.time;
        Debug.Log("Finished");
        yield return null;
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
