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
    bool inRange = false;
    float savedTime;

    void Start()
    {
        MaxHealth = 50;
        Health = MaxHealth;
        Damage = 10;
        MoveSpeed = 10f;

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

        transform.position = Vector2.MoveTowards(rb.position, target, MoveSpeed * Time.fixedDeltaTime);


    }

    // public override void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if (collider.gameObject.tag == "Player")
    //     {
    //         // StartCoroutine(attackRoutine);
    //         inRange = true;
            
    //         if (Time.time - savedTime >= cooldown && inRange && !isAttacking)
    //         {
    //             StartCoroutine(Attack());
    //         }
    //     }
    // }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    public void EnteredTrigger()
    {
        inRange = true;
            
        if (Time.time - savedTime >= cooldown && inRange && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    public void ExitedTrigger()
    {
        inRange = false;
    }

    public override IEnumerator Attack()
    {
        
            isAttacking = true;
            Debug.Log("Attacking");
            //back up
            MoveSpeed = -8f;
            yield return new WaitForSeconds(2f);

            //delay
            MoveSpeed = 0;
            yield return new WaitForSeconds(.5f);

            //charge
            MoveSpeed = 20f;
            yield return new WaitForSeconds(1f);

            MoveSpeed = 10f;
            isAttacking = false;
            savedTime = Time.time;
            Debug.Log("Finished");
        
        yield return null;
    }

    public override void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
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
