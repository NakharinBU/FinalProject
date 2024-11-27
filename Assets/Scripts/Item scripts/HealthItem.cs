using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : Item
{
    private float healthIncrease;

    private void Start()
    {
        healthIncrease = 20;
    }

    public override void AddToPlayer(Player player)
    {
        player.AddValue(healthIncrease);
    }
}
