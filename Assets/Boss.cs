using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Boss : Enemy
{
    public Transform player;
    public bool isFlipped = false;

    private void Start()
    {
        Initialize(2000);
    }

    private void Update()
    {
        if (Health <= 500)
        {
            animator.SetBool("isEnrage", true);
        }
    }

    public void FlipFace()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform not found!");
            return;
        }


        if (transform.position.x > player.position.x && isFlipped)
        {
            Flip();
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFlipped = !isFlipped;

        // Debug ก่อนและหลังการปรับ Scale
        Debug.Log($"Before Flip: {transform.localScale}");

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        Debug.Log($"After Flip: {transform.localScale}");
    }

    public override void AttackWho(Character enemy)
    {
        if (enemy is Player)
        {
            enemy.TakeDamage(DamageHit);
        }
    }
}
