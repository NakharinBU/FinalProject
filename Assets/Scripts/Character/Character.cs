using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health;
    public float Health { get { return health; } set { health = value; } }

    private bool isDie = false;

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
        if (isDie) return;

        Health -= damage;
        HealthBar.UpdateHealthBar(Health);
        if (AlreadyDead())
        {
            isDie = true;

            StartCoroutine(WaitForDeadAnimation());
        }
    }

    public void DestroyCharacter()
    {
        animator.SetTrigger("isDead");
        HealthBar.gameObject.SetActive(false);
        this.enabled = false;
        Destroy(gameObject, 1f);
    }

    IEnumerator WaitForDeadAnimation() 
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        DestroyCharacter();
    }


}
