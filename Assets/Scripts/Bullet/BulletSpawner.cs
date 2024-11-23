using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;


    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;


    private GameObject spawnedBullet;
    private float timer = 0f;
    
    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        if (timer >= firingRate)
        {
            Fire();
            //SpawnCircularBullets();
            timer = 0;
        }
    }


    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<DroneBullet>().speed = speed;
            spawnedBullet.GetComponent<DroneBullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }

    void SpawnCircularBullets()
    {
        int bulletCount = 5;
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            GameObject obj = Instantiate(bullet, transform.position, rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = bullet.transform.up * speed;
        }
    }

}
