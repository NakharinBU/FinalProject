using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            Item item = GetComponent<Item>();

            if (item != null && player != null)
            {
                item.AddToPlayer(player);
                Destroy(gameObject);
            }
        }
    }
}
