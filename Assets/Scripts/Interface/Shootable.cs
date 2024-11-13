using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Shootable
{
    GameObject Bullet { get; set; }

    Transform Transform { get; set; }

    float ReloadTime { get; set; }

    float Wait { get; set; }

    void Shoot();
}
