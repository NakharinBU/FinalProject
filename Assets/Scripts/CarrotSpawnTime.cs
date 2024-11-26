using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpawnTime : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] Transform objTransform;
    private float cd;
    private float maxTime;
    private bool isSpawn;
    private int minCount = 0;
    private int maxCount = 5;

    private void Start()
    {
        isSpawn = false;
        maxTime = 10f;
    }

    private void Update()
    {
        cd += Time.deltaTime;

        if (cd >= maxTime && !isSpawn && minCount < maxCount)
        {
            // Spawn carrot
            Instantiate(obj, objTransform.position, Quaternion.identity);
            minCount++;
            isSpawn = true;
            cd = 0f;
        }
        else if (cd < maxTime)
        {
            isSpawn = false;
        }
    }

}
