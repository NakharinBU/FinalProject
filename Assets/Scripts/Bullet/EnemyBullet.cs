using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Weapon
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float force;
    private float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Move();
    }

    public override void Move()
    {
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    public override void AttackWho(Character enemy)
    {
        if (enemy is Player)
        {
            enemy.TakeDamage(this.Damage);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        AttackWho(other.GetComponent<Character>());
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if(other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
