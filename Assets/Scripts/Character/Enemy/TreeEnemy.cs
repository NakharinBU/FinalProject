using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEnemy : Enemy
{
    [SerializeField] ObjectiveText objectiveText;


    private void Start()
    {
        Initialize(500);
        DamageHit = 10;
    }

    public override void AttackWho(Character enemy)
    {
        if (enemy is Player)
        {
            enemy.TakeDamage(DamageHit);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Tree");
        if (objectiveText != null)
        {
            objectiveText.UpdateKills();
        }
    }


}
