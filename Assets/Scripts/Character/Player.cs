using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : Character, Shootable
{

    [field:SerializeField] public GameObject Bullet { get; set; }

    [field: SerializeField] public Transform Transform { get; set; }

    [field: SerializeField] public float ReloadTime { get; set; }

    [field: SerializeField] public float Wait { get; set; }

    [SerializeField] private bool canFire;

    void Start()
    {
        Initialize(100);

        Wait = 0f;
        ReloadTime = 1.0f;
    }


    void Update()
    {
        Shoot();
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
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            GameObject gameObject = Instantiate(Bullet, Transform.position, Quaternion.identity);

            Bullet bullet = gameObject.GetComponent<Bullet>();

            bullet.InitializeDMG(20, this);


            canFire = false;
        }

    }




}
