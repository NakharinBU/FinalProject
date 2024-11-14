using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health;
    public float Health { get { return health; } set { health = value; } }

    public Rigidbody2D Rigidbody;
    public Animator animator;

    [SerializeField] private HealthBar HealthBar;


    public void Initialize(float newHealth)
    {
        Health = newHealth;
        HealthBar.SetMaxHealth(Health);
        HealthBar.UpdateHealthBar(Health);
    }

    public bool AlreadyDead() 
    {
        return Health <= 0;
    }

    public void TakeDamage(float damage) 
    {
        Health -= damage;
        HealthBar.UpdateHealthBar(Health);
        Debug.Log("Hit");

        if (AlreadyDead())
        {
            animator.SetTrigger("isDead");
            gameObject.SetActive(false);
            this.enabled = false;
        }
    }

    public void DestroyCharacter()
    {
        if (gameObject != null) 
        {
            Destroy(gameObject);
        }
    }
}
