using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public int damage;

    public abstract void Move();

    public abstract void OnTriggerEnter2D(Collider2D collider);

    public abstract void OnTriggerExit2D(Collider2D collider);

    public abstract IEnumerator Attack();

    public abstract void TakeDamage(int damage);

    public abstract void Die();

    public abstract void DropLoot();
}
