using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    [SerializeField] private float force;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        Move();
    }


    public override void Move() 
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    public override void AttackWho(Character enemy)
    {
        if (enemy is Enemy)
        {
            enemy.TakeDamage(this.Damage);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }


}
