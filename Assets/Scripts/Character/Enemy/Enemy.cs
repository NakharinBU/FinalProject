using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    [SerializeField] private float damageHit;
    public float DamageHit { get { return damageHit; } set { damageHit = value; } }

    public abstract void AttackWho(Character enemy);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character != null)
        {
            AttackWho(character);
        }
    }
}
