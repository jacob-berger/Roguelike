using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{

    private int _maxHealth;
    [SerializeField]
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            if (value > 0)
            {
                _maxHealth = value;
            }
        }
    }

    private int _health;
    [SerializeField]
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value > 0)
            {
                _health = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
