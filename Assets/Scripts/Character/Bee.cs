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
        Initialize(100);
        DamageHit = 10;
    }

    public override void AttackWho(Character enemy)
    {
        if (enemy is Player)
        {
            Debug.Log(DamageHit);
            enemy.TakeDamage(DamageHit);
        }
    }


    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

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
                lastAttackTime = Time.time; // µ—Èß‡«≈“‚®¡µ’§√—Èß∂—¥‰ª
            }
        }
    }

}
