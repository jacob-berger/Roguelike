using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

    public int damage = 20;


    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Coll");
            
        }
        if (collision.gameObject.tag == "Trigger")
        {
            Debug.Log("Encountered trigger collider");
            // Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.GetComponent<Collider>());

        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, .5f);
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
