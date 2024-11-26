using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour, Shootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }

    [field: SerializeField] public Transform Transform { get; set; }

    [field: SerializeField] public float ReloadTime { get; set; }

    [field: SerializeField] public float Wait { get; set; }

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 5)
        {
            Wait += Time.deltaTime;
            if (Wait > ReloadTime)
            {
                Wait = 0;
                Shoot();
            }
        }
    }

    public void Shoot() 
    {
        GameObject gameObject = Instantiate(Bullet, Transform.position, Quaternion.identity);

        EnemyBullet bulletDamage = gameObject.GetComponent<EnemyBullet>();

        bulletDamage.InitializeDMG(10, this);


    }

}
