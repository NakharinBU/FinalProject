using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health;
    private float Health { get { return health; } set { health = value; } }

    public Rigidbody2D Rigidbody;
    public Animator animator;

    public void Initialize(float newHealth)
    {
        Health = newHealth;
    }

    public bool AlreadyDead() 
    {
        return Health <= 0;
    }

    public void TakeDamage(float damage) 
    {
        Health -= damage;
        Debug.Log("Hit");

        if (AlreadyDead() == true)
        {
            Destroy(gameObject);
        }
    }

}
