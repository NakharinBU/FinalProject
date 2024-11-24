using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Boss : Enemy
{
    public Transform player;
    public bool isFlipped = false;

    [SerializeField] GameObject objDrone;
    [SerializeField] Transform objTransform;
    private int countDrone = 1;

    [SerializeField] private float timer = 0;
    private float maxTime = 10;


    private void Start()
    {
        Initialize(2000);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (Health <= 1000)
        {
            animator.SetBool("isEnrage", true);
        }
    }

    public void FlipFace()
    {
        if (player == null)
        {
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

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public override void AttackWho(Character enemy)
    {
        if (enemy is Player)
        {
            enemy.TakeDamage(DamageHit);
        }
    }
}
