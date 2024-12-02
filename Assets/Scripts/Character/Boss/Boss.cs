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
    private bool isDroneSpawn;

    [SerializeField] GameObject carrotObj;
    [SerializeField] Transform carrotTransform;
    private bool isCarrotSpawn;



    [SerializeField] private float timer = 0;
    private float maxTime = 10;


    private void Start()
    {
        Initialize(2000);
        isDroneSpawn = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            isDroneSpawn = false;
            timer = 0;
        }

        CheckHealthBoss();
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

    public void Flip()
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

    public void CheckHealthBoss()
    {
        if (Health <= 1000)
        {
            animator.SetBool("isEnrage", true);
        }

        if (Health <= 500 && !isDroneSpawn)
        {
            Instantiate(objDrone, objTransform.position, Quaternion.identity);
            isDroneSpawn = true;
        }

        if (AlreadyDead() && !isCarrotSpawn)
        {
            Instantiate(carrotObj, carrotTransform.position, Quaternion.identity);
            isCarrotSpawn = true;
        }
    }

}
