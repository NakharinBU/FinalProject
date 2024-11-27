using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private float health;
    public float Health { get { return health; } set { health = value; } }

    private bool isDie = false;

    public Rigidbody2D Rigidbody;
    public Animator animator;

    [SerializeField] public HealthBar HealthBar;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float flashDuration = 0.1f;
    private int flashCount = 2;


    public void Initialize(float newHealth)
    {
        Health = newHealth;
        HealthBar.SetMaxHealth(Health);
        HealthBar.UpdateHealthBar(Health);
    }

    public bool AlreadyDead() 
    {
        return Health < 0;
    }

    public void TakeDamage(float damage) 
    {
        if (isDie) return;

        Health -= damage;
        HealthBar.UpdateHealthBar(Health);

        StartCoroutine(FlashOnSprite());

        if (AlreadyDead())
        {
            isDie = true;

            StartCoroutine(WaitForDeadAnimation());
        }
    }

    public void DestroyCharacter()
    {
        this.enabled = false;
        HealthBar.gameObject.SetActive(false);
        Destroy(GetComponent<Collider2D>());
        animator.SetTrigger("isDead");
        Destroy(gameObject, 0.5f);
    }

    IEnumerator WaitForDeadAnimation() 
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        DestroyCharacter();
    }

    private IEnumerator FlashOnSprite() 
    {
        for (int i = 0; i < flashCount; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashDuration);

        }
    }

}
