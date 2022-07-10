using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Actor
{

    private float _moveSpeed;
    public float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }
        set
        {
            if (value > -1)
            {
                _moveSpeed = value;
            }
        }
    }

    private int _damage;
    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            if (value > -1)
            {
                _damage = value;
            }
        }
    }

    public abstract void Move();

    public abstract void OnTriggerEnter2D(Collider2D collider);

    public abstract void OnTriggerExit2D(Collider2D collider);

    public abstract IEnumerator Attack();

    public abstract void TakeDamage(int damage);

    public abstract void Die();

    public abstract void DropLoot();
}
