using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    private float damage;
    public float Damage { get { return damage; } set { damage = value; } }

    protected Shootable shooter;

    public abstract void AttackWho(Character enemy);

    public abstract void Move();

    public void InitializeDMG(float newDamage, Shootable whoShoot)
    {
        damage = newDamage;
        shooter = whoShoot;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AttackWho(other.GetComponent<Character>());
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject, 0.3f);
        }
    }
}
