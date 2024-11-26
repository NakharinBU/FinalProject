using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character, Shootable
{

    [field:SerializeField] public GameObject Bullet { get; set; }

    [field: SerializeField] public Transform Transform { get; set; }

    [field: SerializeField] public float ReloadTime { get; set; }

    [field: SerializeField] public float Wait { get; set; }

    [SerializeField] private bool canFire;

    [SerializeField] private Vector2 spawnPoint;

    private int numOfCarrot;

    void Start()
    {
        Initialize(100);
        spawnPoint = transform.position;

        Wait = 0f;
        ReloadTime = 0.2f;
    }


    void Update()
    {
        Shoot();

        if (this.AlreadyDead())
        {
            PlayerDied();
        }


    }

    private void FixedUpdate()
    {
        if (!canFire)
        {
            Wait += Time.deltaTime;
            if (Wait >= ReloadTime)
            {
                canFire = true;
                Wait = 0;
            }
        }
    }

    public void Shoot()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            GameObject gameObject = Instantiate(Bullet, Transform.position, Quaternion.identity);

            CarrotBullet bullet = gameObject.GetComponent<CarrotBullet>();

            bullet.InitializeDMG(2000, this);

            canFire = false;
        }

    }

    public void SpawnPoint() 
    {
        transform.position = spawnPoint;
        TakeDamage(10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fallblock"))
        {
            SpawnPoint();
        }
    }

    public void PlayerDied() 
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void AddValue(float newHealth)
    {
        Health += newHealth;
        Health = Mathf.Clamp(Health, 0, 100);
        HealthBar.UpdateHealthBar(Health);
        
    }

    public void AddValue(int carrotCount) 
    {
        numOfCarrot += carrotCount;
    }

}
