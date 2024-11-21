using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemy
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float stopDistance;
    private float distance;
    private float attackCooldown = 1.0f;
    private float lastAttackTime;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        Initialize(100);
        DamageHit = 10;
    }

    public override void AttackWho(Character enemy)
    {
        if (enemy is Player)
        {
            enemy.TakeDamage(DamageHit);
        }
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }


        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (player.transform.position.x < transform.position.x && transform.localScale.x > 0)
        {
            // ผู้เล่นอยู่ทางซ้าย bee หันไปทางซ้าย
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (player.transform.position.x > transform.position.x && transform.localScale.x < 0)
        {
            // ผู้เล่นอยู่ทางขวา bee หันไปทางขวา
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (distance < distanceBetween && distance > stopDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        if (distance <= stopDistance && Time.time >= lastAttackTime + attackCooldown) 
        {
            Character playerCharacter = player.GetComponent<Character>();
            if (playerCharacter != null)
            {
                AttackWho(playerCharacter);
                lastAttackTime = Time.time;
            }
        }
    }

}
