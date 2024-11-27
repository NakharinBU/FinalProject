using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotItem : Item
{
    private int carrotCount;

    private void Start()
    {
        carrotCount = 1;
    }

    public override void AddToPlayer(Player player)
    {
        player.AddValue(carrotCount);
    }
}
