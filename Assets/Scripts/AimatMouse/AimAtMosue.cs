using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMosue : MonoBehaviour
{

    [SerializeField] private GameObject aim;

    private Camera mainCamera;

    Player player;

    private Vector3 mousePosition;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = transform.position.z;

        Vector3 rotation = mousePosition - transform.position;

        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);


        Vector3 localScale = new Vector3(1,1,1);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1;
        }
        else 
        {
            localScale.y = 1;
        }

        aim.transform.localScale = localScale;
    }
}
